using System;

namespace XRL.World.Parts.Mutation
{
  [Serializable]
  public class DarkVision : BaseMutation
  {
    public int Radius = 5;

    public DarkVision()
    {
      this.DisplayName = "Night Vision";
    }
    public override bool CanLevel()
    {
      return true;
    }
    public override void Register(GameObject Object)
    {
      base.Register(Object);
    }
    public override string GetDescription()
    {
      return "You see in the dark.";
    }
    public override string GetLevelText(int Level)
    {
      return "You see in the dark, to " + (Level*5) + " distance";;
    }
    public override bool WantEvent(int ID, int cascade)
    {
      if (!base.WantEvent(ID, cascade))
        return ID == BeforeRenderEvent.ID;
      return true;
    }
    public override bool HandleEvent(BeforeRenderEvent E)
    {
      if (this.ParentObject.IsPlayer())
      {
        Cell currentCell = this.ParentObject.CurrentCell;
        if (currentCell != null)
          currentCell.ParentZone.AddLight(currentCell.X, currentCell.Y, this.Radius, LightLevel.Dimvision);
      }
      return true;
    }
    public override bool FireEvent(Event E)
    {
      return base.FireEvent(E);
    }
    public override bool ChangeLevel(int NewLevel)
    {
    this.Radius = 5*NewLevel;
      return base.ChangeLevel(NewLevel);
    }
    public override bool Mutate(GameObject GO, int Level)
    {
    this.Radius = 5*Level;
      return base.Mutate(GO, Level);
    }
    public override bool Unmutate(GameObject GO)
    {
      return base.Unmutate(GO);
    }
  }
}
