                                        // ъпскхм дхдюп дг # 3


using System;
using UnityEngine;

[Serializable]
public class MultiController : MonoBehaviour
{
    public GameObject[] controlledObjects;

    public float speed = 2f;
    public float limit = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(moveHorizontal, 0, moveVertical);

        // 1. сапюк рюй йюй дюфе опх нярюмнбйе он днярхфемхч опедекю лемъчряъ йннпдхмюрш

        //transform.position = transform.position + movementVector * speed * Time.deltaTime;

        if (movementVector != Vector3.zero)
        {
            foreach (GameObject obj in controlledObjects)
            {
                if (obj != null)
                {
                    // 2. сапюк рюй йюй дюфе опх днярхфемхх кхьэ ндмнцн хг оепедекнб (цнпхгнмрюкэмнцн
                    //хкх бепрхйюкэмнцн) назейр онкмнярэч опейпюыюер дбхфемхе б дпсцни окняйнярх

                    //if ((obj.transform.position.x < limit || moveHorizontal < 0) &&
                    //    (obj.transform.position.x > -limit || moveHorizontal > 0) &&
                    //    (obj.transform.position.z < limit || moveVertical < 0) &&
                    //    (obj.transform.position.z > -limit || moveVertical > 0))
                    //{
                    //    obj.transform.Translate(movementVector * speed * Time.deltaTime, Space.World);
                    //}


                    Vector3 newPos = obj.transform.position + movementVector * speed * Time.deltaTime;
                    newPos.x = Mathf.Clamp(newPos.x, -limit, limit);
                    newPos.z = Mathf.Clamp(newPos.z, -limit, limit);

                    obj.transform.position = newPos;
                }
            }
        }
    }
}
