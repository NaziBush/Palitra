using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SpriteData : ScriptableObject
{
    public Sprite[] sprites;
    [Tooltip("Базовая картинка без пустых мест (для определения высоты линии)")]
    public Sprite example;
}
