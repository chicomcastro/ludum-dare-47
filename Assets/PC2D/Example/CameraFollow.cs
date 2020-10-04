using UnityEngine;
using System.Collections;

namespace PC2D
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float speed = 5f;

        public Vector2 minBoundary;

        // Update is called once per frame
        void Update()
        {
            Vector3 pos = transform.position;

            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;

            if (target.position.x - width / 2 >= minBoundary.x)
            {
                pos.x = target.position.x;
            }

            if (target.position.y - height / 2 >= minBoundary.y || target.position.y <= pos.y - height / 2.5)
            {
                pos.y = target.position.y;
            }

            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }
    }
}
