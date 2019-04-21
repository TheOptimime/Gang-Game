﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Enemy_movement : MonoBehaviour {      public Transform target;     public float speed;      // Start is called before the first frame update     void Start()     {         speed = 3;     }      // Update is called once per frame     void Update()     {         Vector3 targetDir = target.position - transform.position;          float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;         Quaternion q = Quaternion.AngleAxis(angle,Vector3.forward);         transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 100);         transform.Translate(Vector3.up * Time.deltaTime *speed);     } }