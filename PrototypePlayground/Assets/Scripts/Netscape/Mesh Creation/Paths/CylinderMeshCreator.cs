using System.Collections.Generic;
using PathCreation.Utility;
using UnityEngine;

namespace PathCreation.Examples
{
    public class CylinderMeshCreator : PathSceneTool
    {
        //The thickness of the circle
        public float thickness = .15f;

        //How hollow the mesh is
        [Range(0, 1)]
        public float innerThickness = 0;
        //The resolution of the round-ness of the circle
        [Range(3, 30)]
        public int resolutionU = 10;
        //Basically how accurately it follows the path
        [Min(0)]
        public float resolutionV = 20;

        public float verticalUVScale;
        [Range(0,1)]
        public float horizontalUVOffset;

        public Material material;

        [SerializeField, HideInInspector]
        GameObject meshHolder;

        MeshFilter meshFilter;
        MeshRenderer meshRenderer;
        Mesh mesh;

        protected override void PathUpdated()
        {
            if (pathCreator != null)
            {
                AssignMeshComponents();
                AssignMaterials();
                CreateMesh();
            }
        }

        void CreateMesh()
        {
            //Our list of vertices
            List<Vector3> verts = new List<Vector3>();
            //Our list of triangles
            List<int> triangles = new List<int>();
            //Our list of triangles
            List<int> trianglesInner = new List<int>();
            //Our UVs
            List<Vector2> uv = new List<Vector2>();

            //Essentially the number of circles we are using the mesh, based on resolutionV;
            int numCircles = Mathf.Max(2, Mathf.RoundToInt(path.length * resolutionV) + 1);
            var pathInstruction = PathCreation.EndOfPathInstruction.Stop;

            //So we need to iterate through the circles
            for (int s = 0; s < numCircles; s++)
            {
                //See how far along we are as a percentage
                float segmentPercent = s / (numCircles - 1f);
                //Get the center of this circle and make it our center position
                Vector3 centerPos = path.GetPointAtTime(segmentPercent, pathInstruction);
                //Get the normal along this point in the path in order to figure which way is up so we can rotate around it
                Vector3 norm = path.GetNormal(segmentPercent, pathInstruction);
                //Get the forward direction, assists in getting where the circle is facing
                Vector3 forward = path.GetDirection(segmentPercent, pathInstruction);
                //Using the cross product we can find the forward direction of the cylinder segment, neat.
                Vector3 tangentOrWhatEver = Vector3.Cross(norm, forward);

                //This iterates through our circle resolution to contstruct this segment on our cylinder
                for (int currentRes = 0; currentRes < resolutionU; currentRes++)
                {
                    //Basically, since we're making a circle, we are getting where along the circle we would be based on the point we are at
                    var angle = ((float)currentRes / resolutionU) * (Mathf.PI * 2.0f);

                    //This just makes it thicker
                    var xVal = Mathf.Sin(angle) * thickness;
                    var yVal = Mathf.Cos(angle) * thickness;
                    //This gets a vector3 for that point in meshspace
                    var point = (norm * xVal) + (tangentOrWhatEver * yVal) + centerPos;
                    verts.Add(point);
                    float u = (angle / (Mathf.PI * 2.0f));
                    Vector2 thisUV = new Vector2(u, segmentPercent * verticalUVScale);
                    uv.Add(thisUV);

                    //! Adding the triangles
                    if (s < numCircles - 1)
                    {
                        
                        int startIndex = resolutionU * s;

                        triangles.Add(startIndex + currentRes);
                        triangles.Add(startIndex + (currentRes + 1) % resolutionU);
                        triangles.Add(startIndex + currentRes + resolutionU);

                        triangles.Add(startIndex + (currentRes + 1) % resolutionU);
                        triangles.Add(startIndex + (currentRes + 1) % resolutionU + resolutionU);
                        triangles.Add(startIndex + (currentRes) + resolutionU);
                    }

                    

                }
            }

            int indexAdd = verts.Count;

            for (int s = 0; s < numCircles; s++)
            {
                //See how far along we are as a percentage
                float segmentPercent = s / (numCircles - 1f);
                //Get the center of this circle and make it our center position
                Vector3 centerPos = path.GetPointAtTime(segmentPercent, pathInstruction);
                //Get the normal along this point in the path in order to figure which way is up so we can rotate around it
                Vector3 norm = path.GetNormal(segmentPercent, pathInstruction);
                //Get the forward direction, assists in getting where the circle is facing
                Vector3 forward = path.GetDirection(segmentPercent, pathInstruction);
                //Using the cross product we can find the forward direction of the cylinder segment, neat.
                Vector3 tangentOrWhatEver = Vector3.Cross(norm, forward);

                if (innerThickness > 0 && innerThickness <= 1)
                {
                    for (int currentRes = 0; currentRes < resolutionU; currentRes++)
                    {
                        //Basically, since we're making a circle, we are getting where along the circle we would be based on the point we are at
                        var angle = ((float)currentRes / resolutionU) * (Mathf.PI * 2.0f);

                        //This just makes it thicker
                        var xVal = Mathf.Sin(angle) * thickness * innerThickness;
                        var yVal = Mathf.Cos(angle) * thickness * innerThickness;

                        //This gets a vector3 for that point in meshspace
                        var point = (norm * xVal) + (tangentOrWhatEver * yVal) + centerPos;
                        verts.Add(point);
                        float u = ((float)currentRes /(resolutionU - 1));
                        Vector2 thisUV = new Vector2(u, segmentPercent * verticalUVScale);
                        uv.Add(thisUV);

                        //! Adding the triangles
                        if (s < numCircles - 1)
                        {

                            int startIndex = indexAdd + resolutionU * s;

                            triangles.Add(startIndex + currentRes + resolutionU);
                            triangles.Add(startIndex + (currentRes + 1) % resolutionU);
                            triangles.Add(startIndex + currentRes);

                            triangles.Add(startIndex + currentRes + resolutionU);
                            triangles.Add(startIndex + (currentRes + 1) % resolutionU + resolutionU);
                            triangles.Add(startIndex + (currentRes + 1) % resolutionU);
                        }

                    }
                }
            }


            if (mesh == null)
            {
                mesh = new Mesh();
            }
            else
            {
                mesh.Clear();
            }

            mesh.SetVertices(verts);
            mesh.subMeshCount = 2;
            mesh.SetTriangles(triangles, 0);
            //mesh.SetTriangles(trianglesInner, 0);
            mesh.SetUVs(0, uv);
            mesh.RecalculateNormals();

        }

        // Add MeshRenderer and MeshFilter components to this gameobject if not already attached
        void AssignMeshComponents()
        {

            if (meshHolder == null)
            {
                meshHolder = new GameObject("Mesh Holder");
            }

            meshHolder.transform.rotation = Quaternion.identity;
            meshHolder.transform.position = Vector3.zero;
            meshHolder.transform.localScale = Vector3.one;

            // Ensure mesh renderer and filter components are assigned
            if (!meshHolder.gameObject.GetComponent<MeshFilter>())
            {
                meshHolder.gameObject.AddComponent<MeshFilter>();
            }
            if (!meshHolder.GetComponent<MeshRenderer>())
            {
                meshHolder.gameObject.AddComponent<MeshRenderer>();
            }

            meshRenderer = meshHolder.GetComponent<MeshRenderer>();
            meshFilter = meshHolder.GetComponent<MeshFilter>();
            if (mesh == null)
            {
                mesh = new Mesh();
            }
            meshFilter.sharedMesh = mesh;
        }

        void AssignMaterials()
        {
            if (material != null)
            {
                meshRenderer.sharedMaterial = material;
            }
        }

    }
}