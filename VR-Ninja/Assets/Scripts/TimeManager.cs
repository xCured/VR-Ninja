using UnityEngine;
using VRTK;
using static VRTK.VRTK_ControllerEvents;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    public  bool SlowPls = false;
    public bool SetFixedDelta = false;


    public static float SP = 100.0f;

    public float StaminaRegenTimer = 2.0f;
    public const float SPDecreasePerFrame = 4.0f;
    public const float SPIncreasePerFrame = 10.0f;
    private const float StaminaTimeToRegen = 2.0f;
    public float MaxSP = 100.0f;



   public void SlowMo()
    {
        //timescale = 1 it would be real time
        //timescale = 0.5 it would be 2x slower
        SlowPls = !SlowPls;
        SetFixedDelta = !SetFixedDelta;

        if(SetFixedDelta == false)
        {
            Time.fixedDeltaTime = 1.0f;
        }

    }



    //use -4 p/s
    // not used for 1 second recover 10 p/s




    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(SlowPls);
        //Debug.Log(SP);
        if (SlowPls == true)
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            SP = Mathf.Clamp(SP - ((SPDecreasePerFrame * Time.deltaTime) * 8), 0.0f, MaxSP);
            Debug.Log(SP);

            StaminaRegenTimer = 0.0f;
            
        }

        if (SP == 0)
        {
            Time.fixedDeltaTime = 1.0f;
            SlowPls = false;
        }

        if(SlowPls == false)
        {
            Time.timeScale = 1.0f;
           
            if (SP < 100f) { 
                if(StaminaRegenTimer >= StaminaTimeToRegen)
                 {
                    SP = Mathf.Clamp(SP + (SPIncreasePerFrame * Time.deltaTime), 0.0f, MaxSP);

                }
                else
                {
                    StaminaRegenTimer += Time.deltaTime;
                }
            }
           
        }
        if (SP > 100)
        {
            SP = 100;
        }
    }

    //if button pressed trigger, SlowPls = true
    //Timescale = 0.7
    //if button pressed trigger, slowpls = false;
    //timescale = 1
    //if stamina ==0 SlowPls = false

}
