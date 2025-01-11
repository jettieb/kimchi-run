using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    public float minSpawnDelay; //새로운 객체를 만들기 위해 최소 몇 초를 기다려야 하는가
    public float maxSpawnDelay;

    [Header("References")]
    public GameObject[] gameObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }

    void Spawn(){
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        //생성 - 위치에 spawner의 position 넣기, rotation.
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));    //2초 후에 spawn 생성
    }
}
