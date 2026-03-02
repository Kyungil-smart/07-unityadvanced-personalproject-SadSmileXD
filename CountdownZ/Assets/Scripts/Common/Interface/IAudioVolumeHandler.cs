using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioVolumeHandler  
{
  public event Action<float> OnValueChanageActions;
  
     
}
