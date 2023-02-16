using UnityEditor;
using UnityEngine;

public class ParticleSystemUndo : Editor
{
    [InitializeOnLoadMethod]
    public static void AddUndoSupportForParticleSystem()
    {
        Undo.willFlushUndoRecord += BeforeUndo;
        Undo.undoRedoPerformed   += RestorePS;
    }

    private static void BeforeUndo()
    {
        if (!IsParticleSelected(out _))
            return;
    }

    private static void RestorePS()
    {
        if (IsParticleSelected(out var ps)) return;
        ps.Play();
    }

    private static bool IsParticleSelected(out ParticleSystem ps)
    {
        ps = default;
        var selected = Selection.activeGameObject;
        if (selected == null || !selected.TryGetComponent(out ps))
            return true;
        return false;
    }
}