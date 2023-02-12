using Entitas;
using UnityEngine;

public class InputSystem : IInitializeSystem, IExecuteSystem
{
    private          Camera      m_camera;
    private readonly Contexts    m_contexts;
    private          InputEntity m_leftMouseEntity;
    private          InputEntity m_rightMouseEntity;
    private const    int         LMB = 0, RMB = 1;

    public InputSystem(Contexts contexts)
    {
        m_contexts = contexts;
        m_camera = Camera.main;
    }
    public void Initialize()
    {
        m_contexts.input.isLeftMouse  = true;
        m_leftMouseEntity             = m_contexts.input.leftMouseEntity;
        m_contexts.input.isRightMouse = true;
        m_rightMouseEntity            = m_contexts.input.rightMouseEntity;
    }

    public void Execute()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(LMB)) m_leftMouseEntity.ReplaceMouseDown(mousePos);
        if (Input.GetMouseButtonUp(LMB)) m_leftMouseEntity.ReplaceMouseUp(mousePos);
        if (Input.GetMouseButton(LMB)) m_leftMouseEntity.ReplaceMouseHold(mousePos);

        if (Input.GetMouseButtonDown(RMB)) m_rightMouseEntity.ReplaceMouseDown(mousePos);
        if (Input.GetMouseButtonUp(RMB)) m_rightMouseEntity.ReplaceMouseUp(mousePos);
        if (Input.GetMouseButton(RMB)) m_rightMouseEntity.ReplaceMouseHold(mousePos);
    }
}
