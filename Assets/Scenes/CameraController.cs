using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //回転速度
    [Range(0f, 1f)] public float rotationSpeed = 1f;
    //縦方向の角度(上側）
    [Range(0f, 90f)] public float max_rotation_x = 80f;
    //縦方向の角度(下側)
    [Range(0f, 90f)] public float min_rotation_x = 80f;
    //左右方向の最大角度(左右対称のため最大のみ)
    [Range(0f, 180f)] public float max_rotation_y = 180f;
    //現在の回転角度
    private float rotation_x = 0f;
    private float rotation_y = 0f;

    // Update is called once per frame
    void Update()
    {
        //左矢印キーが押されたとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //カメラの横左方向の角度の範囲を指定
            if (rotation_y < -max_rotation_y)
            {
                //範囲外のときreturnして処理させない
                return;
            }
            //現在の回転角度を変更
            rotation_y -= rotationSpeed;
            //y軸を軸に左回りにrotationSpeed度回転
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }
        //右矢印キーが押されたとき
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //カメラの横右方向の角度の範囲を指定
            if (rotation_y > max_rotation_y)
            {
                //範囲外のときreturnして処理させない
                return;
            }
            //現在の回転角度を変更
            rotation_y += rotationSpeed;
            //y軸を軸に左回りにrotationSpeed度回転
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }

        //上矢印キーが押されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //カメラの縦方向の角度の範囲を指定
            if (rotation_x < -max_rotation_x)
            {
                //範囲外のときreturnして処理させない
                return;
            }
            //現在の回転角度を変更
            rotation_x -= rotationSpeed;
            //x軸を軸に上方向に回転
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }
        //下矢印キーが押されたとき
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //カメラの縦方向の角度の範囲を指定
            if (rotation_x > min_rotation_x)
            {
                //範囲外のときreturnして処理させない
                return;
            }
            //現在の回転角度を変更
            rotation_x += rotationSpeed;
            //x軸を軸に上方向に回転
            transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        }
    }
}