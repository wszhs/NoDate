﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class LevelConfig
{

    private LevelConfigElem[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("elem", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public LevelConfigElem[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class LevelConfigElem
{

    private string nameField;
    private string numberField;

    private string themeField;

    private string typeField;

    private string timeOutField;

    private string scoreField;

    private string filenameField;
    private string maxcountField;
    private string musicField;
    private string ismoveField;
    private string showbloodField;
    private string dietimeField;
    private string isdoublesceneField;
    private string haveparticleField;
    private string havecoinField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }
    public string number
    {
        get
        {
            return this.numberField;
        }
        set
        {
            this.numberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string theme
    {
        get
        {
            return this.themeField;
        }
        set
        {
            this.themeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string timeOut
    {
        get
        {
            return this.timeOutField;
        }
        set
        {
            this.timeOutField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string score
    {
        get
        {
            return this.scoreField;
        }
        set
        {
            this.scoreField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string filename
    {
        get
        {
            return this.filenameField;
        }
        set
        {
            this.filenameField = value;
        }
    }

    public string maxcount
    {
        get
        {
            return this.maxcountField;
        }
        set
        {
            this.maxcountField = value;
        }
    }
    public string music
    {
        get
        {
            return this.musicField;
        }
        set
        {
            this.musicField = value;
        }
    }
    public string ismove
    {
        get
        {
            return this.ismoveField;
        }
        set
        {
            this.ismoveField = value;
        }
    }
    public string showblood
    {
        get
        {
            return this.showbloodField;
        }
        set
        {
            this.showbloodField = value;
        }
    }
    public string dietime
    {
        get
        {
            return this.dietimeField;
        }
        set
        {
            this.dietimeField = value;
        }
    }

    public string isdoublescene {

        get {
            return this.isdoublesceneField;
        }
        set {
            this.isdoublesceneField = value;
        }
    }

    public string haveparticle
    {

        get
        {
            return this.haveparticleField;
        }
        set
        {
            this.haveparticleField = value;
        }
    }

    public string havecoin
    {

        get
        {
            return this.havecoinField;
        }
        set
        {
            this.havecoinField = value;
        }
    }
}