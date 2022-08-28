using UnityEngine;

public class DNA : MonoBehaviour
{
    //genes for color of gameobject
    public float r;
    public float g;
    public float b;
    private float a = 1;

    //genes for size of gameObject
    public float size;


    //gene for storing age. this will allow us to find the longest lived person in the gene pool.
    public float timeToDie = 0;


    void Start()
    {

        //changing the color of the gameObject based on random values recieved from the gameManager.
        this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(r, g, b, a);

        //chaning the height of the gameObject based on random values recieved from the gameManager.
        this.gameObject.transform.localScale = new Vector3(size, size, size);
    }

    private void OnMouseDown()
    {

        //this gets timetodie of a dna sequence.
        timeToDie = GameManager.timeElapsed;

        //turning off their sprite renderer so they are not visible
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        //turning off their sprite collider so they are not clickable as well
        this.gameObject.GetComponent<Collider2D>().enabled = false;

    }
}