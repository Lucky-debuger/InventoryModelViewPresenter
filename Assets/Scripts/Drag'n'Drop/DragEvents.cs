using System;

public static class DragEvents // [ ] Точно ли безопасно создавать static и должен ли он быть singalton?
{
    public static event Action OnInventoryDragStart;
    public static event Action OnInventoryDragEnd;

    public static void InvokeInventoryDragStart() => OnInventoryDragStart?.Invoke();
    public static void InvokeInventoryDragEnd() => OnInventoryDragEnd?.Invoke();
}
