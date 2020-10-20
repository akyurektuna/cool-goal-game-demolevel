using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Vector3 mouseReleasePos2;
    private Rigidbody rb;

    private bool isShoot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag() {
        drawRoute(mousePressDownPos);    
    }
    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
    }

    //????????**********
    private void drawRoute(Vector3 pos){
        var line = this.GetComponent<LineRenderer>();
        if( line == null ){
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material( Shader.Find( "Sprites/Default" ) ) { color = Color.yellow };
            line.SetWidth( 0.3f, 0.3f );
            line.SetColors( Color.yellow, Color.yellow );
        }
        mouseReleasePos2 = Input.mousePosition;
        Vector3 extendedVector = (mouseReleasePos2-pos);
        extendedVector = Quaternion.Euler(90, -90, 90) * extendedVector;
        line.SetPosition(0,-extendedVector);
    }

    private float forceMultiplier = 4;
    void Shoot(Vector3 Force)
    {
        if(isShoot)    
            return;
        
        rb.AddForce(new Vector3(Force.x,Force.y,Force.y) * forceMultiplier);
        isShoot = true;
    }
    
}