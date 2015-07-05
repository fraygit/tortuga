using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace tortuga.Data
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class UserProfile : Entity<int>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateUnique]
    [ValidateLength(0, 56)]
    private string _userName;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the UserName entity attribute.</summary>
    public const string UserNameField = "UserName";


    #endregion
    
    #region Relationships

    [ReverseAssociation("UserProfile")]
    private readonly EntityCollection<UserProfileOrganisation> _userProfileOrganisations = new EntityCollection<UserProfileOrganisation>();

    private ThroughAssociation<UserProfileOrganisation, Organisation> _organisations;

    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<UserProfileOrganisation> UserProfileOrganisations
    {
      get { return Get(_userProfileOrganisations); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public ThroughAssociation<UserProfileOrganisation, Organisation> Organisations
    {
      get
      {
        if (_organisations == null)
        {
          _organisations = new ThroughAssociation<UserProfileOrganisation, Organisation>(_userProfileOrganisations);
        }
        return Get(_organisations);
      }
    }
    

    [System.Diagnostics.DebuggerNonUserCode]
    public string UserName
    {
      get { return Get(ref _userName, "UserName"); }
      set { Set(ref _userName, value, "UserName"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class Organisation : Entity<int>
  {
    #region Fields
  
    private string _name;
    private string _description;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Name entity attribute.</summary>
    public const string NameField = "Name";
    /// <summary>Identifies the Description entity attribute.</summary>
    public const string DescriptionField = "Description";


    #endregion
    
    #region Relationships

    [ReverseAssociation("Organisation")]
    private readonly EntityCollection<UserProfileOrganisation> _userProfileOrganisations = new EntityCollection<UserProfileOrganisation>();

    private ThroughAssociation<UserProfileOrganisation, UserProfile> _userProfiles;

    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public EntityCollection<UserProfileOrganisation> UserProfileOrganisations
    {
      get { return Get(_userProfileOrganisations); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public ThroughAssociation<UserProfileOrganisation, UserProfile> UserProfiles
    {
      get
      {
        if (_userProfiles == null)
        {
          _userProfiles = new ThroughAssociation<UserProfileOrganisation, UserProfile>(_userProfileOrganisations);
        }
        return Get(_userProfiles);
      }
    }
    

    [System.Diagnostics.DebuggerNonUserCode]
    public string Name
    {
      get { return Get(ref _name, "Name"); }
      set { Set(ref _name, value, "Name"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Description
    {
      get { return Get(ref _description, "Description"); }
      set { Set(ref _description, value, "Description"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class UserProfileOrganisation : Entity<int>
  {
    #region Fields
  
    private int _userProfileId;
    private int _organisationId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the UserProfileId entity attribute.</summary>
    public const string UserProfileIdField = "UserProfileId";
    /// <summary>Identifies the OrganisationId entity attribute.</summary>
    public const string OrganisationIdField = "OrganisationId";


    #endregion
    
    #region Relationships

    [ReverseAssociation("UserProfileOrganisations")]
    private readonly EntityHolder<UserProfile> _userProfile = new EntityHolder<UserProfile>();
    [ReverseAssociation("UserProfileOrganisations")]
    private readonly EntityHolder<Organisation> _organisation = new EntityHolder<Organisation>();


    #endregion
    
    #region Properties

    [System.Diagnostics.DebuggerNonUserCode]
    public UserProfile UserProfile
    {
      get { return Get(_userProfile); }
      set { Set(_userProfile, value); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public Organisation Organisation
    {
      get { return Get(_organisation); }
      set { Set(_organisation, value); }
    }


    [System.Diagnostics.DebuggerNonUserCode]
    public int UserProfileId
    {
      get { return Get(ref _userProfileId, "UserProfileId"); }
      set { Set(ref _userProfileId, value, "UserProfileId"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int OrganisationId
    {
      get { return Get(ref _organisationId, "OrganisationId"); }
      set { Set(ref _organisationId, value, "OrganisationId"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the TortugaModel model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class TortugaModelUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<UserProfile> UserProfiles
    {
      get { return this.Query<UserProfile>(); }
    }
    
    public System.Linq.IQueryable<Organisation> Organisations
    {
      get { return this.Query<Organisation>(); }
    }
    
    public System.Linq.IQueryable<UserProfileOrganisation> UserProfileOrganisations
    {
      get { return this.Query<UserProfileOrganisation>(); }
    }
    
  }

}
