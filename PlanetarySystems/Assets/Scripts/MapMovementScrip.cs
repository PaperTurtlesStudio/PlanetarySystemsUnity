using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovementScrip : MonoBehaviour
{
    public Transform PlayerCharacter;
    public GameObject PlayerCharacterIcon;
    Rigidbody2D IconRigidbody;
    Vector2 CurrentPlayerPosition;
    float PlayerRotation;

    public Transform SpaceShip;
    public Transform SpaceshipIcon;
    public Transform Village;
    public Transform VillageIcon;


    // Start is called before the first frame update
    void Start()
    {
        IconRigidbody = PlayerCharacterIcon.GetComponent<Rigidbody2D>();
        PlayerCharacterIcon.transform.localPosition = new Vector2(PlayerCharacter.position.x, PlayerCharacter.position.z);
        SpaceshipIcon.localPosition = new Vector3(SpaceShip.position.x, SpaceShip.position.z);
        VillageIcon.localPosition = new Vector3(Village.position.x, Village.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCharacterIcon.transform.localPosition = new Vector2(PlayerCharacter.position.x, PlayerCharacter.position.z);
        PlayerCharacterIcon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -PlayerCharacter.rotation.eulerAngles.y);
    }
}
