using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
   
    public int currentRoom ;      // กล้องเริ่มต้น เช่น 1
    private float moveCooldown =8 ;  // ทุกๆ 8 วิ จะพยายามย้าย
    float timer;
    [Header ("REF")]
    [SerializeField]AudioManager audioManager;
    [SerializeField] GameObject[] rooms;       // จุดตำแหน่งกล้อง Cam1–Cam8
    [SerializeField] GameObject Bg;
    [SerializeField] GameObject jumpScareImage;
    public PowerBattery playerDoor;        // ห้องผู้เล่น

    void Start()
    {
        currentRoom = rooms.Length;
        timer = moveCooldown;
        UpdateRoomActive();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            MoveToNextRoom();
            timer = moveCooldown;
        }
    }

    void MoveToNextRoom()
    {
         moveCooldown = Random.Range(6,8);
        // ถ้าถึงห้องผู้เล่น
        if (currentRoom == 1)   // ยกตัวอย่างว่า Cam1 คือ "หน้าห้องผู้เล่น"
        {
            TryEnterPlayerRoom();
            return;
        }

        // ถ้ายังไม่ถึงห้องผู้เล่น - ขยับไปข้างหน้า
        currentRoom--;
        UpdateRoomActive();
    }

    void TryEnterPlayerRoom()
    {
        // ถ้าประตูปิด
        if (playerDoor.isDoorOpen == false)
        {
            audioManager.PlaySFX(audioManager.doorClick);
            currentRoom = Random.Range(5,rooms.Length);
            UpdateRoomActive();
        }
        else
        {

            // ประตูเปิด → Game Over
           audioManager.PlaySFX(audioManager.doorClick);
           StartCoroutine(CountDownEnd(Random.Range(3,5)));
            return;
        }
    }

    void UpdateRoomActive()
    {
        // ปิดทุกห้องก่อน
        foreach (var r in rooms)
            r.SetActive(false);

        // เปิดห้องปัจจุบัน
        rooms[currentRoom -1 ].SetActive(true);
    }
    IEnumerator CountDownEnd(float countDown)
    {
        //ใส่เสียง

        yield return new WaitForSeconds(countDown);
        if (playerDoor.isDoorOpen == false)
        {
            audioManager.PlaySFX(audioManager.doorClick);
            currentRoom = Random.Range(5,rooms.Length);
            UpdateRoomActive();
        }
        else
        {
            StartCoroutine(JumpScare());
            yield break;
        }

        yield return null;
    }
    public IEnumerator JumpScare()
    {
        Bg.SetActive(true);
        yield return new WaitForSeconds(Random.Range(1,3));
        jumpScareImage.SetActive(true);
        audioManager.PlaySFX(audioManager.jumpScareSFX);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("BadEnd"); 
    }

}
