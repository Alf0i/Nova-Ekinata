using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObjetivoSM 
{

    void PrepararObjetivo(Transform[] objs);

    bool AtualizarObjetivo(Transform[] objs);

    void SairObjetivo(Transform[] objs);
}
