using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Knife knife))
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Animator>().SetBool("Explode", true);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<FixedJoint>().connectedBody = knife.GetComponent<Rigidbody>();
            Invoke("DisJoint", 2f);
        }
    }
    private void DisJoint() => Destroy(GetComponent<FixedJoint>());
}
