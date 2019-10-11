using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CustomEditorGUI
{
    /// <summary>
    /// This will replace the class's editor within the inspector
    /// sliders https://docs.unity3d.com/ScriptReference/EditorGUILayout.Slider.html
    /// remove script https://answers.unity.com/questions/316286/how-to-remove-script-field-in-inspector.html
    /// editor https://docs.unity3d.com/ScriptReference/Editor.html
    /// </summary>
    [CustomEditor(typeof(PlayerMovement))]
    [CanEditMultipleObjects]
    public class PlayerMovementGUI : Editor
    {
        private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

        SerializedProperty speedProp;

        private void OnEnable()
        {
            speedProp = serializedObject.FindProperty("speed");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUIContent labelSpeed = new GUIContent("Speed", "The Player's movespeed (must be high)");
            EditorGUILayout.Slider(speedProp, 0, 1000, labelSpeed);
            
            DrawPropertiesExcluding(serializedObject, _dontIncludeMe);

            serializedObject.ApplyModifiedProperties();
        }
    }

    [CustomEditor(typeof(PlayerHealth))]
    [CanEditMultipleObjects]
    public class PlayerHealthGUI : Editor
    {
        private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

        SerializedProperty healthProp;
        SerializedProperty invProp;

        private void OnEnable()
        {
            healthProp = serializedObject.FindProperty("maxHealth");
            invProp = serializedObject.FindProperty("invincibilityTime");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUIContent labelHealth = new GUIContent("Max Health", "The Player's max health amount");
            EditorGUILayout.Slider(healthProp, 0, 500, labelHealth);

            GUIContent labelInvincibilityTime = new GUIContent("Invincibility Time", "After being damaged, the time needed to pass before the player can be damaged again");
            EditorGUILayout.Slider(invProp, 0, 2, labelInvincibilityTime);
            
            DrawPropertiesExcluding(serializedObject, _dontIncludeMe);

            serializedObject.ApplyModifiedProperties();
        }
    }

    [CustomEditor(typeof(Enemy))]
    [CanEditMultipleObjects]
    public class EnemyGUI : Editor
    {
        private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

        SerializedProperty healthProp;
        SerializedProperty knockbackProp;

        private void OnEnable()
        {
            healthProp = serializedObject.FindProperty("maxHealth");
            knockbackProp = serializedObject.FindProperty("knockbackForce");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUIContent labelMaxHealth = new GUIContent("Max Health", "The enemy's max health");
            EditorGUILayout.Slider(healthProp, 0, 1000, labelMaxHealth);

            GUIContent labelKnockbackForce = new GUIContent("Knockback Force", "The force at which the enemy is knocked away when hitting the player (needs to be high)");
            EditorGUILayout.Slider(knockbackProp, 0, 200, labelKnockbackForce);

            DrawPropertiesExcluding(serializedObject, _dontIncludeMe);

            serializedObject.ApplyModifiedProperties();
        }
    }

    [CustomEditor(typeof(Arrow))]
    [CanEditMultipleObjects]
    public class ArrowGUI : Editor
    {
        private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

        SerializedProperty speedProp;
        SerializedProperty despawnProp;

        private void OnEnable()
        {
            speedProp = serializedObject.FindProperty("speed");
            despawnProp = serializedObject.FindProperty("despawnTime");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUIContent labelSpeed = new GUIContent("Speed", "The arrow's movement speed");
            EditorGUILayout.Slider(speedProp, 0, 30, labelSpeed);

            GUIContent labelDespawnTime = new GUIContent("Despawn Time", "The amount of time the arrow can exist for before automatically being destroyed");
            EditorGUILayout.Slider(despawnProp, 0, 2, labelDespawnTime);
            
            DrawPropertiesExcluding(serializedObject, _dontIncludeMe);

            serializedObject.ApplyModifiedProperties();
        }
    }
}

