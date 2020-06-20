using UnityEngine;

public class CameraController : MonoBehaviour
{
  [Header("Camera Options")]
  public float panSpeed = 30f;
  // public float panBoarderThickness = 10f;
  public float scrollSpeed = 10f;
  public float minY = 10f;
  public float maxY = 80f;

  // Update is called once per frame
  void Update()
  {
    //Enable or disable movement.
    if (GameManager.GameEnded)
    {
      return;
    }

    //Basic movement commands.
    if (Input.GetKey("w"))
    {
      transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
    }
    if (Input.GetKey("s"))
    {
      transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
    }
    if (Input.GetKey("d"))
    {
      transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
    }
    if (Input.GetKey("a"))
    {
      transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
    }

    /*Scrolling settings*/
    float scroll = Input.GetAxis("Mouse ScrollWheel");
    Vector3 pos = transform.position;

    pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
    pos.y = Mathf.Clamp(pos.y, minY, maxY);

    transform.position = pos;
  }
}
