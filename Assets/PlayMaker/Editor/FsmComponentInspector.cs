// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using HutongGames.PlayMaker;
using HutongGames.PlayMakerEditor;
using System.Collections.Generic;

/// <summary>
/// Custom inspector for PlayMakerFSM
/// </summary>
[CustomEditor(typeof(PlayMakerFSM))]
public class FsmComponentInspector : Editor
{
    /// <summary>
    /// Inspector target
    /// </summary>
    PlayMakerFSM fsmComponent;

    /// <summary>
    /// fsmComponent template
    /// </summary>
    FsmTemplate fsmTemplate;

    /// <summary>
    /// serializedObject was added to Editor in 3.5
    /// </summary>
#if UNITY_3_4
    SerializedObject serializedObject;
#endif  
    
    // Label for watermark button
    [System.NonSerialized]
    private GUIContent watermarkLabel;

    public GUIContent WatermarkLabel
    {
        get
        {
            return watermarkLabel ?? (watermarkLabel = new GUIContent
            {
                text = FsmEditorUtility.GetWatermarkLabel(fsmComponent, Strings.Tooltip_Choose_Watermark),
                tooltip = Strings.Hint_Watermarks
            });
        }
    }

    // Foldout states

    private bool showControls = true;
    private bool showInfo;
    private bool showStates;
    private bool showEvents;
    private bool showVariables;

    // Fsm Variables

    List<FsmVariable> fsmVariables = new List<FsmVariable>();

    [Localizable(false)]
    public void OnEnable()
    {
        fsmComponent = target as PlayMakerFSM;

        // can happen when playmaker is updated?
        if (fsmComponent != null)
        {

#if UNITY_3_4
            serializedObject = new SerializedObject(fsmComponent);
#endif                        
            fsmTemplate = fsmComponent.FsmTemplate;
            
            if (fsmTemplate != null)
            {
                VerifyTemplateVariables();
            }
                       
            BuildFsmVariableList();
        }
    }

    public override void OnInspectorGUI()
    {
        // can happen when playmaker is updated...?

        if (fsmComponent == null)
        {
            return;
        }

        // Make sure common PlayMaker styles are initialized

        FsmEditorStyles.Init();

        // Begin GUI

        var fsm = fsmComponent.Fsm;
        fsm.Owner = fsmComponent; // since Owner is no longer serialized

        if (fsm.States.Length > 100)
        {
            EditorGUILayout.HelpBox("NOTE: Collapse this inspector for better editor performance with large FSMs.", MessageType.None);
        }

        // FSM Name        

        EditorGUILayout.BeginHorizontal();

        fsm.Name = EditorGUILayout.TextField(fsm.Name);

        if (GUILayout.Button(new GUIContent(Strings.Label_Edit, Strings.Tooltip_Edit_in_the_PlayMaker_Editor), GUILayout.MaxWidth(45)))
        {
            OpenInEditor(fsmComponent);
            GUIUtility.ExitGUI();
        }

        EditorGUILayout.EndHorizontal();

        // FSM Template

        EditorGUILayout.BeginHorizontal();
        
        var template = (FsmTemplate)
            EditorGUILayout.ObjectField(new GUIContent(Strings.Label_Use_Template, Strings.Tooltip_Use_Template),
                fsmComponent.FsmTemplate, typeof(FsmTemplate), false);

        if (template != fsmComponent.FsmTemplate)
        {
            fsmComponent.SetFsmTemplate(template);
        }

        if (GUILayout.Button(new GUIContent(Strings.Label_Browse, Strings.Tooltip_Browse_Templates), GUILayout.MaxWidth(45)))
        {
            DoSelectTemplateMenu();
        }

        EditorGUILayout.EndHorizontal();

        if (!Application.isPlaying && fsmComponent.FsmTemplate != null)
        {
            template = fsmComponent.FsmTemplate;
            fsm = template.fsm;

            GUI.enabled = false;
        }

        // Description

        fsm.Description = FsmEditorGUILayout.TextAreaWithHint(fsm.Description, Strings.Label_Description___, GUILayout.MinHeight(60));

        // Help Url

        EditorGUILayout.BeginHorizontal();

        fsm.DocUrl = FsmEditorGUILayout.TextFieldWithHint(fsm.DocUrl, Strings.Tooltip_Documentation_Url);

        var guiEnabled = GUI.enabled;

        GUI.enabled = !string.IsNullOrEmpty(fsm.DocUrl);

        if (FsmEditorGUILayout.HelpButton())
        {
            Application.OpenURL(fsm.DocUrl);
        }

        EditorGUILayout.EndHorizontal();

        GUI.enabled = guiEnabled;

        // Basic Settings
        
        fsm.RestartOnEnable = GUILayout.Toggle(fsm.RestartOnEnable, new GUIContent(Strings.Label_Reset_On_Disable, Strings.Tooltip_Reset_On_Disable));
        fsm.ShowStateLabel = GUILayout.Toggle(fsm.ShowStateLabel, new GUIContent(Strings.Label_Show_State_Label, Strings.Tooltip_Show_State_Label));
        fsm.EnableDebugFlow = GUILayout.Toggle(fsm.EnableDebugFlow, new GUIContent(Strings.FsmEditorSettings_Enable_DebugFlow, Strings.FsmEditorSettings_Enable_DebugFlow_Tooltip));

        if (GUI.changed)
        {
            EditorUtility.SetDirty(fsmComponent);
        }

        GUI.enabled = true;

        // VARIABLES

        FsmEditorGUILayout.LightDivider();
        showControls = EditorGUILayout.Foldout(showControls, new GUIContent(Strings.Label_Controls, Strings.Tooltip_Controls), FsmEditorStyles.CategoryFoldout);

        if (showControls)
        {
            //EditorGUIUtility.LookLikeInspector();

            BuildFsmVariableList();

            foreach (var fsmVar in fsmVariables)
            {
                if (fsmVar.ShowInInspector)
                {
                    const string next = ":\n";
                    fsmVar.DoValueGUI(new GUIContent(fsmVar.Name, fsmVar.Name + (!string.IsNullOrEmpty(fsmVar.Tooltip) ? next + fsmVar.Tooltip : "")));
                }
            }

            if (GUI.changed)
            {
                FsmEditor.RepaintAll();
            }
        }

        // EVENTS

        if (showControls)
        {
            foreach (var fsmEvent in fsm.ExposedEvents)
            {
                GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel(fsmEvent.Name);
                if (GUILayout.Button(fsmEvent.Name))
                {
                    fsm.Event(fsmEvent);
                    FsmEditor.RepaintAll();
                }
                GUILayout.EndHorizontal();
            }
        }

        //INFO

        EditorGUI.indentLevel = 0;

        FsmEditorGUILayout.LightDivider();
        showInfo = EditorGUILayout.Foldout(showInfo, Strings.Label_Info, FsmEditorStyles.CategoryFoldout);

        if (showInfo)
        {
            EditorGUI.indentLevel = 1;

            showStates = EditorGUILayout.Foldout(showStates, string.Format(Strings.Label_States_Count, fsm.States.Length));
            if (showStates)
            {
                string states = "";

                if (fsm.States.Length > 0)
                {
                    foreach (var state in fsm.States)
                    {
                        states += FsmEditorStyles.tab2 + state.Name + FsmEditorStyles.newline;
                    }
                    states = states.Substring(0, states.Length - 1);
                }
                else
                {
                    states = FsmEditorStyles.tab2 + Strings.Label_None_In_Table;
                }

                GUILayout.Label(states);
            }

            showEvents = EditorGUILayout.Foldout(showEvents, string.Format(Strings.Label_Events_Count, fsm.Events.Length));
            if (showEvents)
            {
                var events = "";

                if (fsm.Events.Length > 0)
                {
                    foreach (var fsmEvent in fsm.Events)
                    {
                        events += FsmEditorStyles.tab2 + fsmEvent.Name + FsmEditorStyles.newline;
                    }
                    events = events.Substring(0, events.Length - 1);
                }
                else
                {
                    events = FsmEditorStyles.tab2 + Strings.Label_None_In_Table;
                }

                GUILayout.Label(events);
            }

            showVariables = EditorGUILayout.Foldout(showVariables, string.Format(Strings.Label_Variables_Count, fsmVariables.Count));
            if (showVariables)
            {
                var variables = "";

                if (fsmVariables.Count > 0)
                {
                    foreach (var fsmVar in fsmVariables)
                    {
                        variables += FsmEditorStyles.tab2 + fsmVar.Name + FsmEditorStyles.newline;
                    }
                    variables = variables.Substring(0, variables.Length - 1);
                }
                else
                {
                    variables = FsmEditorStyles.tab2 + Strings.Label_None_In_Table;
                }

                GUILayout.Label(variables);
            }
        }
    }

    public static void OpenInEditor(PlayMakerFSM fsmComponent)
    {
        if (FsmEditor.Instance == null)
        {
            FsmEditorWindow.OpenWindow(fsmComponent);
        }
        else
        {
            FsmEditor.SelectFsm(fsmComponent.FsmTemplate == null ? fsmComponent.Fsm : fsmComponent.FsmTemplate.fsm);
        }
    }

    public static void OpenInEditor(Fsm fsm)
    {
        if (fsm.Owner != null)
        {
            OpenInEditor(fsm.Owner as PlayMakerFSM);
        }
    }

    public static void OpenInEditor(GameObject go)
    {
        if (go != null)
        {
            OpenInEditor(FsmEditorUtility.FindFsmOnGameObject(go));
        }
    }
    
    void BuildFsmVariableList()
    {
        fsmVariables = FsmVariable.GetFsmVariableList(fsmComponent.Fsm.Variables, target);

        fsmVariables.Sort();
    }

    #region Templates

    void SelectTemplate(object userdata)
    {
        SelectTemplate(userdata as FsmTemplate);
    }

    void SelectTemplate(FsmTemplate template)
    {
        fsmComponent.SetFsmTemplate(template);
        fsmTemplate = template;

        CopyTemplateVariables();
        BuildFsmVariableList();

        EditorUtility.SetDirty(fsmComponent);
    }

    void ClearTemplate()
    {
        fsmComponent.Reset();
        fsmTemplate = null;

        BuildFsmVariableList();

        if (FsmEditor.SelectedFsmComponent == fsmComponent)
        {
            FsmEditor.SelectFsm(fsmComponent.Fsm);
        }
    }

    void DoSelectTemplateMenu()
    {
        var menu = new GenericMenu();

        var templates = (FsmTemplate[])FindObjectsOfTypeIncludingAssets(typeof(FsmTemplate));

        menu.AddItem(new GUIContent(Strings.Menu_None), false, ClearTemplate);

        foreach (var template in templates)
        {
            const string submenu = "/";
            menu.AddItem(new GUIContent(template.Category + submenu + template.name), fsmComponent.FsmTemplate == template, SelectTemplate, template);
        }

        menu.ShowAsContext();
    }

    void CopyTemplateVariables()
    {
        fsmComponent.Fsm.Variables = new FsmVariables(fsmTemplate.fsm.Variables);
    }

    void VerifyTemplateVariables()
    {
        var currentValues = new FsmVariables(fsmComponent.Fsm.Variables);

        CopyTemplateVariables();

        fsmComponent.Fsm.Variables.OverrideVariableValues(currentValues);
    }

    #endregion

    public void OnSceneGUI()
    {
        FsmEditor.OnSceneGUI();
    }
}


