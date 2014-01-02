using UnityEngine;
using System.Collections;
[AddComponentMenu ("MyGame/Player")]
public class Player : MonoBehaviour 
{				
			//声音//
			public AudioClip m_shootclip;
			
			//声音源//
			protected AudioSource m_audio;
	
			//爆炸特效//
			public Transform m_explosionFX;
	
			public GameObject projectile; 
			//移动速度//
			public float m_speed = 4;
			//public float m_speed1 = 4;
			//子弹Prefab//
			public Transform m_rocket;
			//子弹速度
			 float m_rocktRate=0;
			protected Transform m_transform;
			
			//生命属性//
			public float m_life= 3;
			
			
			//记录手指
			// Use this for initialization
			void Start () 
			{
				m_audio= this.audio;
		
				m_transform = this.transform;	
				        // 允许多点触控//
        		//Input.multiTouchEnabled = true;//
		
				
			}
			
			// Update is called once per frame
			void Update () 
			{
				#if !UNITY_EDITOR && ( UNITY_IOS || UNITY_ANDROID ) 
							rocktRate();
		                   MobileInput(); 
				#else
							rocktRate();
						   WinInput();
				#endif


			}
			void 	rocktRate(){				//发射子弹//
					m_rocktRate -= Time.deltaTime;

					if (m_rocktRate <= 0)
						{   
						m_rocktRate = 0.6f;
					   // if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))//
														//射击声音//
						m_audio.PlayOneShot(m_shootclip);
							Instantiate(m_rocket, m_transform.position, m_transform.rotation);	

						}
					}
			void WinInput(){

					//上下移动距离//
					float movev = 0;
					//左右移动距离//
					float moveh = 0;
					//按上//
					if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
					{
						movev += m_speed * Time.deltaTime;
					}
					//按下//
					if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
					{
						movev -= m_speed * Time.deltaTime;
					}
					//按左//
					if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
					{
						moveh -= m_speed * Time.deltaTime; 
					}
					//按右//
					if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
					{
						moveh += m_speed * Time.deltaTime; 
					}
				   

					//移动//
					this.m_transform.Translate(new Vector3(moveh, movev,0 ));
					}
			void MobileInput(){
					//MOB移动速//
			OnMouseDown ();
				}
			IEnumerator OnMouseDown ()
	{
		Vector3 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 mScreenPosition=new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint( mScreenPosition);
		while (Input.GetMouseButton (0))
		{
			mScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
			Vector3 pos = offset + Camera.main.ScreenToWorldPoint (mScreenPosition);
			pos.z = 0;
			transform.position = pos;
			yield return new WaitForFixedUpdate ();
		}
	}		
			void OnTriggerEnter(Collider other)
				{
								if (m_life <=0)
		{
			//爆炸特效
			Instantiate(m_explosionFX,m_transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}
						if (other.tag.CompareTo("Enemy")==0)
						{
								Debug.Log ("P");
								Destroy(this.gameObject);
						Instantiate(m_explosionFX,m_transform.position,Quaternion.identity);
						} 

		}
					
}