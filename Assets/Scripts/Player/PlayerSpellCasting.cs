using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpellCasting : MonoBehaviour
{
    public static PlayerSpellCasting Instance;
    public MagicData magicRightClick;
    public MagicData magicOffensive;
    public MagicData magicDefensive;
    public MagicData magicUltimate;

    public float cooldownRightClick;
    public float cooldownOffsensive;
    public float cooldownDefensive;
    public float cooldownUltimate;

    public event Action onClickBaseMagic;
    public event Action onClickOffensiveMagic;
    public event Action onClickDefensiveMagic;
    public event Action onClickUltimateMagic;


    [SerializeField] private Animator staffAnimator;
    private void Awake()
    {
        if (PlayerDontDestroy.Instance && PlayerDontDestroy.Instance.gameObject != transform.parent.gameObject) return;
        Instance = this;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
    }

    private void Start()
    {
        if (SaveLoadManager.Instance)
        {
            PlayerStats.coins = SaveLoadManager.PlayerData.gold;
            PlayerStats.progress = SaveLoadManager.PlayerData.progress;
            if (SaveLoadManager.PlayerData.justStarting)
            {
                SaveLoadManager.PlayerData.justStarting = false;
                SaveLoadManager.PlayerData.baseMagicID = Random.Range(0, MagicManager.Instance.basicMagicsList.Count);
                SaveLoadManager.PlayerData.offensiveMagicID =
                    Random.Range(0, MagicManager.Instance.offensiveMagicsList.Count);
                SaveLoadManager.PlayerData.defensiveMagicID =
                    Random.Range(0, MagicManager.Instance.defensiveMagicsList.Count);
                SaveLoadManager.PlayerData.ultimateMagicID =
                    Random.Range(0, MagicManager.Instance.ultimateMagicsList.Count);

            }
//            print(SaveLoadManager.PlayerData.offensiveMagicID);

            magicRightClick = MagicManager.Instance.basicMagicsList[SaveLoadManager.PlayerData.baseMagicID];
            magicOffensive = MagicManager.Instance.offensiveMagicsList[SaveLoadManager.PlayerData.offensiveMagicID];
            magicDefensive = MagicManager.Instance.defensiveMagicsList[SaveLoadManager.PlayerData.defensiveMagicID];
            magicUltimate = MagicManager.Instance.ultimateMagicsList[SaveLoadManager.PlayerData.ultimateMagicID];

            SaveLoadManager.Instance.SaveGame();
        }

        UpdateSpells();
    }

    public void UpdateSpells()
    {
        int basicMagicID = MagicManager.Instance.basicMagicsList.IndexOf(magicRightClick);
        int offensiveMagicID = MagicManager.Instance.offensiveMagicsList.IndexOf(magicOffensive);
        int defensiveMagicID = MagicManager.Instance.defensiveMagicsList.IndexOf(magicDefensive);
        int ultimateMagicID = MagicManager.Instance.ultimateMagicsList.IndexOf(magicUltimate);
        SelectBaseMagic(basicMagicID);
        SelectOffensiveMagic(offensiveMagicID);
        SelectDefensiveMagic(defensiveMagicID);
        SelectUltimateMagic(ultimateMagicID);
        if (SaveLoadManager.Instance)
        {
            SaveLoadManager.PlayerData.baseMagicID = basicMagicID;
            SaveLoadManager.PlayerData.offensiveMagicID = offensiveMagicID;
          //  print(offensiveMagicID);
           // print(SaveLoadManager.PlayerData.offensiveMagicID);
            SaveLoadManager.PlayerData.defensiveMagicID = defensiveMagicID;
            SaveLoadManager.PlayerData.ultimateMagicID = ultimateMagicID;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.Gameplay) return;

        ReduceCooldowns();
        
        if (Input.GetButton("Fire1"))
        {
            if (cooldownRightClick > 0) return;
            onClickBaseMagic?.Invoke();
            staffAnimator.Play("StaffCast");
        }
        if (Input.GetButton("Fire2"))
        {
            if (cooldownDefensive > 0) return;
            onClickDefensiveMagic?.Invoke();
            staffAnimator.Play("StaffCast");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cooldownOffsensive > 0) return;
            onClickOffensiveMagic?.Invoke();
            staffAnimator.Play("StaffCast");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (cooldownUltimate > 0) return;
            onClickUltimateMagic?.Invoke();
            staffAnimator.Play("StaffCast");
        }
    }

    public void ReduceCooldowns()
    {
        cooldownRightClick -= Time.deltaTime;
        HUDManager.Instance.UpdateCooldownFill(cooldownRightClick, magicRightClick.cooldown, MagicType.Basic);
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Basic, magicRightClick.magicIcon);
        cooldownOffsensive -= Time.deltaTime;
        HUDManager.Instance.UpdateCooldownFill(cooldownOffsensive, magicOffensive.cooldown, MagicType.Offensive);
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Offensive, magicOffensive.magicIcon);
        cooldownDefensive -= Time.deltaTime;
        HUDManager.Instance.UpdateCooldownFill(cooldownDefensive, magicDefensive.cooldown, MagicType.Defensive);
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Defensive, magicDefensive.magicIcon);
        cooldownUltimate -= Time.deltaTime;
        HUDManager.Instance.UpdateCooldownFill(cooldownUltimate, magicUltimate.cooldown, MagicType.Ultimate);
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Ultimate, magicUltimate.magicIcon);

    }

    public void RerollMagic(MagicType type)
    {
        switch (type)
        {
            case MagicType.Basic:
                magicRightClick =
                    MagicManager.Instance.basicMagicsList[Random.Range(0, MagicManager.Instance.basicMagicsList.Count)];
                UpdateSpells();
                break;
            case MagicType.Offensive:
                magicOffensive =
                    MagicManager.Instance.offensiveMagicsList[Random.Range(0, MagicManager.Instance.offensiveMagicsList.Count)];
                UpdateSpells();
                break;
            case MagicType.Defensive:
                magicDefensive =
                    MagicManager.Instance.defensiveMagicsList[Random.Range(0, MagicManager.Instance.defensiveMagicsList.Count)];
                UpdateSpells();
                break;
            case MagicType.Ultimate:
                magicUltimate =
                    MagicManager.Instance.ultimateMagicsList[Random.Range(0, MagicManager.Instance.ultimateMagicsList.Count)];
                UpdateSpells();
                break;
        }
        
        if (SaveLoadManager.Instance) SaveLoadManager.Instance.SaveGame();
    }

    public void RerollAllMagics()
    {
       // print(SaveLoadManager.PlayerData.offensiveMagicID);
        magicRightClick =
            MagicManager.Instance.basicMagicsList[Random.Range(0, MagicManager.Instance.basicMagicsList.Count)];
        magicOffensive =
            MagicManager.Instance.offensiveMagicsList[Random.Range(0, MagicManager.Instance.offensiveMagicsList.Count)];
        magicDefensive =
            MagicManager.Instance.defensiveMagicsList[Random.Range(0, MagicManager.Instance.defensiveMagicsList.Count)];
        magicUltimate =
            MagicManager.Instance.ultimateMagicsList[Random.Range(0, MagicManager.Instance.ultimateMagicsList.Count)]; 
        UpdateSpells();
//        print(SaveLoadManager.PlayerData.offensiveMagicID);
        if(SaveLoadManager.Instance) SaveLoadManager.Instance.SaveGame();
    }

    public void UltimateBlock()
    {
        StartCoroutine(UltimateBlockCoroutine());
    }

    public IEnumerator UltimateBlockCoroutine()
    {
        cooldownUltimate = int.MaxValue;
        HUDManager.Instance.ultimateBlockText.gameObject.SetActive(true);
        yield return new WaitForSeconds(HUDManager.Instance.FadeTime * 3f) ;
        HUDManager.Instance.ultimateBlockText.GetComponent<TextMeshProUGUI>().DOFade(0, HUDManager.Instance.FadeTime);
    }

    public void ResetCooldowns()
    {
        cooldownDefensive = 0;
        cooldownOffsensive = 0;
        cooldownUltimate = 0;
        cooldownRightClick = 0;
    }

    public void SelectBaseMagic(int ID)
    {
        onClickBaseMagic = null;
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Basic, magicRightClick.magicIcon);
        HUDManager.Instance.UpdateTooltips(MagicType.Basic, magicRightClick.magicDescription);

        switch (ID)
        {
            case 0:
                onClickBaseMagic += CastFireball;
                break;
            case 1:
                onClickBaseMagic += CastWaterBubble;
                break;
        }
    }

    public void SelectOffensiveMagic(int ID)
    {
        onClickOffensiveMagic = null;
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Offensive, magicOffensive.magicIcon);
        HUDManager.Instance.UpdateTooltips(MagicType.Offensive, magicOffensive.magicDescription);

        switch (ID)
        {
            case 0:
                onClickOffensiveMagic += CastStaticField;
                break;
            case 1:
                onClickOffensiveMagic += CastIceMissile;
                break;
            case 2:
                onClickOffensiveMagic += CastElectroSphere;
                break;
            case 3:
                onClickOffensiveMagic += CastIceSpikes;
                break;
            case 4:
                onClickOffensiveMagic += CastFireShotgun;
                break;
        }
    }


    public void SelectDefensiveMagic(int ID)
    {
        onClickDefensiveMagic = null;
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Defensive, magicDefensive.magicIcon);
        HUDManager.Instance.UpdateTooltips(MagicType.Defensive, magicDefensive.magicDescription);

        switch (ID)
        {
            case 0:
                onClickDefensiveMagic += CastWindWall;
                break;
            case 1:
                onClickDefensiveMagic += CastIceFloor;
                break;
            case 2:
                onClickDefensiveMagic += CastShield;
                break;
        }
    }

    public void SelectUltimateMagic(int ID)
    {
        onClickUltimateMagic = null;
        HUDManager.Instance.UpdateCooldownSprite(MagicType.Ultimate, magicUltimate.magicIcon);
        HUDManager.Instance.UpdateTooltips(MagicType.Ultimate, magicUltimate.magicDescription);

        switch (ID)
        {
            case 0:
                onClickUltimateMagic += CastLightPillar;
                break;
            case 1:
                onClickUltimateMagic += CastVortex;
                break;
        }
    }

    private void CastVortex()
    {
        cooldownUltimate = magicUltimate.cooldown;
        GameObject temp = Instantiate(magicUltimate.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

        temp.GetComponent<SpellDamager>().damage = magicUltimate.baseDamage * PlayerStats.damageMultiplier;
    }

    private void CastShield()
    {
        cooldownDefensive = magicDefensive.cooldown;
        PlayerCollision.Instance.shield.SetActive(true);
    }

    private void CastLightPillar()
    {
        cooldownUltimate = magicUltimate.cooldown;
        GameObject temp = Instantiate(magicUltimate.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

        temp.transform.GetChild(0).GetComponent<SpellDamager>().damage = magicUltimate.baseDamage * PlayerStats.damageMultiplier;
    }
    
    private void CastIceMissile()
    {
        cooldownOffsensive = magicOffensive.cooldown;
        GameObject temp = Instantiate(magicOffensive.magicPrefab, PlayerManager.Instance.spellSpawnPoint.transform.position, Quaternion.identity);

        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - PlayerManager.Instance.spellSpawnPoint.transform.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * magicOffensive.baseSpeed;

        temp.GetComponent<SpellDamager>().damage = magicOffensive.baseDamage * PlayerStats.damageMultiplier;
        RotateTowardsMouse(180, temp);
    }
    
    private void CastElectroSphere()
    {
        cooldownOffsensive = magicOffensive.cooldown;
        GameObject temp = Instantiate(magicOffensive.magicPrefab, transform.position, Quaternion.identity);
        temp.GetComponent<ElectrosphereParent>().damage = magicOffensive.baseDamage;
        temp.GetComponent<ElectrosphereParent>().Initialize();
    }
    
    private void CastIceSpikes()
    {
        cooldownOffsensive = magicOffensive.cooldown;
        GameObject temp = Instantiate(magicOffensive.magicPrefab, transform.position, Quaternion.identity);
        temp.GetComponent<IceSpikesParent>().damage = magicOffensive.baseDamage;
        temp.GetComponent<IceSpikesParent>().Initialize();
    }
    
    private void CastIceFloor()
    {
        cooldownDefensive = magicDefensive.cooldown;
        GameObject temp = Instantiate(magicDefensive.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }


    private void CastWindWall()
    {
        cooldownDefensive = magicDefensive.cooldown;
        Instantiate(magicDefensive.magicPrefab, transform.position, Quaternion.identity);
    }

    private void CastStaticField()
    {
        cooldownOffsensive = magicOffensive.cooldown;
        GameObject temp = Instantiate(magicOffensive.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

        temp.GetComponent<SpellDamager>().damage = magicOffensive.baseDamage * PlayerStats.damageMultiplier;
    }

    public void CastFireball()
    {
        cooldownRightClick = magicRightClick.cooldown;
        GameObject temp = Instantiate(magicRightClick.magicPrefab, PlayerManager.Instance.spellSpawnPoint.transform.position, Quaternion.identity);

        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - PlayerManager.Instance.spellSpawnPoint.transform.position;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * magicRightClick.baseSpeed;

        temp.GetComponent<SpellDamager>().damage = magicRightClick.baseDamage * PlayerStats.damageMultiplier;
    }
    
    private void CastFireShotgun()
    {
        cooldownOffsensive = magicOffensive.cooldown;
        GameObject temp = Instantiate(magicOffensive.magicPrefab, PlayerManager.Instance.spellSpawnPoint.transform.position, Quaternion.identity);

        RotateTowardsMouse(180, temp);
        
        temp.GetComponent<FireBoulderParent>().Initialize(magicRightClick.baseDamage * PlayerStats.damageMultiplier);    
    }
    
    public void CastWaterBubble()
    {
        cooldownRightClick = magicRightClick.cooldown;
        GameObject temp = Instantiate(magicRightClick.magicPrefab, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

        temp.GetComponent<SpellDamager>().damage = magicRightClick.baseDamage * PlayerStats.damageMultiplier;
    }
    
    private void RotateTowardsMouse(float angleOffset, GameObject objectToRotate)
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (staffAnimator.transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        objectToRotate.transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle + angleOffset));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
