using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour {
	
	//得分
	public int m_point=10;
	//声音
	public AudioClip m_shootclip;
	//声音源
	protected AudioSource m_audio;
	//爆炸特效
	public Transform m_explosionFX;
	
	//速度
	public float m_speed=1;
	//旋转速度
	protected float m_rotSpeed=30;
	//变向间隔时间
	protected float m_timer=1.5f;
	//m_timer 是一个计时器
	protected Transform m_transform;
	//生命属性
	public float m_life= 1;
		

	// Use this for initialization
	void Start () {
		m_transform=this.transform;
		
		m_audio=this.audio;
		
	//创建生命条

	
	}
	
	// Update is called once per frame
	void Update () {
	
		UpdateMove();
	}
	protected virtual void UpdateMove()
	{
		m_timer -= Time.deltaTime;
		if(m_timer<=0)
		{
			m_timer=3;
			
			//改变旋转方向//
			m_rotSpeed = -m_rotSpeed;
		}
		
		//旋转方向//
		//m_transform.Rotate(Vector3.up,m_rotSpeed*Time.deltaTime,Space.World);
		//m_transform.Rotate 用来旋转敌人的游戏体//
		//前进//
		m_transform.Translate(new Vector3(0,-m_speed*Time.deltaTime,0));
		
		
	}
	

	//碰撞检测
    void OnTriggerEnter(Collider other)
    {
		 if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;

                if (m_life <= 0)
				{
					GameManager.Instance.AddScore(m_point);
					//爆炸特效//
					Instantiate(m_explosionFX,m_transform.position,Quaternion.identity);
					Debug.Log ("D");
					Destroy(this.gameObject);
				}
			}
		}
        else if (other.tag.CompareTo("Player1")==0)
		{
			Instantiate(m_explosionFX,m_transform.position,Quaternion.identity);
				Debug.Log ("E");
				m_life=0;
				Destroy(this.gameObject);
			
		}
		if (other.tag.CompareTo("bound")==0)
		{
			m_life=0;
			
			Destroy(this.gameObject);
		}
    }	

}