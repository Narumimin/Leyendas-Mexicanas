using UnityEngine;

public class UI_Control : MonoBehaviour
{
    private bool canvasControlesActivo = false;
    public Canvas panelControles;
    public Canvas panelMenuPrincipal;

    public void ToggleControles()
    {
        canvasControlesActivo = !canvasControlesActivo;

        if (panelControles != null)
        {
            panelControles.enabled = canvasControlesActivo;
            panelMenuPrincipal.enabled = !canvasControlesActivo;
        }
    }



}
