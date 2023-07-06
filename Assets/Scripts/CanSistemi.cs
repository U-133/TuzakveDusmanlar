using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanSistemi : MonoBehaviour
{
    public int maxCan = 5; // Maksimum can say�s�
    [SerializeField] private int currentCan; // Mevcut can say�s�

    public void Start()
    {
        currentCan = maxCan; // Oyun ba�lang�c�nda canlar� maksimuma ayarla
    }

    public void CanAzalt(int miktar)
    {
        currentCan -= miktar; // Can� azalt

        if (currentCan <= 0)
        {
            // Can s�f�r veya daha azsa, karakter �ld�
            KarakteriOldur();
        }
    }

    private void KarakteriOldur()
    {
        Destroy(this.gameObject);
    }
}

