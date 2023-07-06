using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanSistemi : MonoBehaviour
{
    public int maxCan = 5; // Maksimum can sayýsý
    [SerializeField] private int currentCan; // Mevcut can sayýsý

    public void Start()
    {
        currentCan = maxCan; // Oyun baþlangýcýnda canlarý maksimuma ayarla
    }

    public void CanAzalt(int miktar)
    {
        currentCan -= miktar; // Caný azalt

        if (currentCan <= 0)
        {
            // Can sýfýr veya daha azsa, karakter öldü
            KarakteriOldur();
        }
    }

    private void KarakteriOldur()
    {
        Destroy(this.gameObject);
    }
}

