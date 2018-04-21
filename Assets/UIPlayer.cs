using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour {


  // SINGLETON
  public static UIPlayer m_instance;
  void Awake() {
    if (m_instance == null) {
      //If I am the first instance, make me the Singleton
      m_instance = this;
      Init();
    } else {
      if (this != m_instance) {
        Destroy(gameObject);
      }
    }
  }

  // UNITY VAR
  [SerializeField] List<GameObject> hearts;
  [SerializeField] List<GameObject> swords;
  [SerializeField] Image map;

  // VAR
  int currentHeart;
  int currentSword;

  /// <summary>
  /// Start this instance.
  /// </summary>
  void Init() {
    currentHeart = 0;
    currentSword = 0;
    foreach (var go in hearts) {
      go.SetActive(false);
    }
    foreach (var go in swords) {
      go.SetActive(false);
    }
  }

  public void AddHeart() {
    if (currentHeart < hearts.Count()) {
      hearts[currentHeart].SetActive(true);
      currentHeart++;
    }
  }

  public void RemoveHeart() {
    if (currentHeart > 1) {
      hearts[currentHeart - 1].SetActive(false);
      currentHeart--;
    }
  }

  public void AddSword() {
    if (currentSword < swords.Count()) {
      swords[currentSword].SetActive(true);
      currentSword++;
    }
  }

  public void RemoveSword() {
    if (currentSword > 1) {
      swords[currentSword - 1].SetActive(false);
      currentSword--;
    }
  }

  public void displayMap(Sprite _sprite) {
    map.sprite = _sprite;
  }
}
