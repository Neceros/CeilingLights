using UnityEngine;
using Verse;

namespace CeilingLights
{
  public class CeilingLightsSettings : ModSettings
  {
    public static int GrowLightPowerConsumption => growLPC;

    // despite the public flag, don't reference the below var(s); they're only public for the purposes of the mod settings screen below. Reference the above variables instead.
    public static int growLPC;
    public static string growLPCTooltip = ""; // Cant translate CLSettingsGrowLPCTooltip for some reason

    public override void ExposeData()
    {
      base.ExposeData();
      Scribe_Values.Look(ref growLPC, "growLightPowerConsumption");
    }
  }

  public class CeilingLightsMod : Mod
  {
    CeilingLightsSettings settings;
    public CeilingLightsMod(ModContentPack con) : base(con)
    {
      this.settings = GetSettings<CeilingLightsSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
      Listing_Standard listing = new Listing_Standard();
      listing.Begin(inRect);
      listing.TextFieldNumericLabeled<int>("CLSettingsGrowLPC".Translate(), ref CeilingLightsSettings.growLPC, ref CeilingLightsSettings.growLPCTooltip);
      listing.End();
      base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
      // This is the title on the mod screen
      return "CLSettingsCategory".Translate();
    }
  }
}
