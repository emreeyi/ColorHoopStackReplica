using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject HareketPozisyonu;
    public GameObject[] Soketler;
    public int BosOlanSoket;
    public List<GameObject> _Cemberler;
    [SerializeField] private GameManager _GameManager;
    int CemberTamamlanmaSayisi;
    public GameObject EnUsttekiCemberiVer()
    {
        return _Cemberler[_Cemberler.Count-1];
    }
    public GameObject MusaitSoketiVer()
    {
        return Soketler[BosOlanSoket];
    }
    public void SoketDegistirmeIslemleri(GameObject SilinecekObje)
    {
        _Cemberler.Remove(SilinecekObje);
        if (_Cemberler.Count != 0)
        {
            BosOlanSoket--;
            _Cemberler[_Cemberler.Count - 1].GetComponent<Cember>().HareketEdebilirmi = true;
        }
        else
        {
            BosOlanSoket = 0;
        }
    }
    public void CemberleriKontrolEt()
    {
        if (_Cemberler.Count == 4)
        {
            string Renk = _Cemberler[0].GetComponent<Cember>().Renk;
            foreach (var item in _Cemberler)
            {
                if (Renk == item.GetComponent<Cember>().Renk)
                {
                    CemberTamamlanmaSayisi++;
                }
            }
            if (CemberTamamlanmaSayisi == 4)
            {
                _GameManager.StandTamamlandi();
                TamamlanmisStandIslemleri();
            }
            else
            {
                CemberTamamlanmaSayisi = 0;
            }
        }
    }
    void TamamlanmisStandIslemleri()
    {
        foreach (var item in _Cemberler)
        {
            item.GetComponent<Cember>().HareketEdebilirmi = false;
            Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
            color.a = 150;
            item.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
            gameObject.tag = "TamamlanmýsStand";
        }
    }
}