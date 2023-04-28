using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILocal
{
    void localInteraction(Player player, Clock time);

    void localChoice(bool more);

    void localDialogue(bool more);
}
