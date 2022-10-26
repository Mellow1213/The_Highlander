using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    EnemyWaveSystem _enemyWaveSystem;
    // Start is called before the first frame update
    void Start()
    {
        _enemyWaveSystem = GetComponent<EnemyWaveSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Wave Level\n" + _enemyWaveSystem.waveLevel + "\nLeft Waves\n" + _enemyWaveSystem.getLeftWave();
    }
}
