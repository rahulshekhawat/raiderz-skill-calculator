using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace RaiderzSkillTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Additional variables
        private int physicalDamageReduction;
        private int magicDamageReduction;
        private string fileName;

        // Constants
        private const int MaxSkillPoints = 50;
        // Variables used in all tabs
        private string baseSkillTree;
        private int allocatedSkillPoints;
        private int remainingSkillPoints;
        private int assassinSkillPoints;
        private int berserkerSkillPoints;
        private int clericSkillPoints;
        private int defenderSkillPoints;
        private int sorcererSkillPoints;

        // Variables local to Assassin's tab
        private int chaosPoints;
        private int cleavePoints;
        private int cyclonePoints;
        private int endurancePoints;
        private int daggermasteryPoints;
        private int leapPoints;
        private int stabPoints;
        private int resPoints;
        private int stormPoints;
        private int penePoints;
        private int blinkPoints;
        private int acrobaticsPoints;
        private int bicyclePoints;
        private int veilPoints;
        private int adrenPoints;
        private int dragonPoints;
        private int whirlPoints;
        private int seizePoints;
        private int shadowstrikePoints;
        private int shadowdancePoints;
        private int fortPoints;
        private int bladedancePoints;
        private int invigPoints;
        private int coldbloodedPoints;

        // Variables local to Berserker's tab
        private int crushPoints;
        private int neutralizePoints;
        private int dodgePoints;
        private int noMercyPoints;
        private int twoHandedPoints;
        private int nocturnePoints;
        private int berserkPoints;
        private int buffaloPoints;
        private int furiousPoints;
        private int feastPoints;
        private int vanquishPoints;
        private int armageddonPoints;
        private int inertiaPoints;
        private int tranquilityPoints;
        private int crueltyPoints;
        private int bashPoints;
        private int scamperPoints;
        private int woundsPoints;
        private int upwardPoints;
        private int escapePoints;
        private int tornadoPoints;
        private int madnessPoints;
        private int zerkBloodPoints;

        // Variables local to Cleric's tab
        private int lightPoints;
        private int divinePoints;
        private int revitalizePoints;
        private int repercussionPoints;
        private int divineMasteryPoints;
        private int focusedPoints;
        private int enduranceBlessingPoints;
        private int pleasurePoints;
        private int judgePoints;
        private int copPoints;
        private int cohPoints;
        private int mindTrainingPoints;
        private int healingPoints;
        private int direPoints;
        private int concentrationPoints;
        private int arbitrationPoints;
        private int linksPoints;
        private int recoveryPoints;
        private int orbsPoints;
        private int goddessPoints;
        private int upliftPoints;
        private int whirlpoolPoints;
        private int salvationPoints;
        private int swiftnessPoints;
        private int priestPoints;
        private int stormJudgementPoints;
        private int nimblePoints;

        // Variables local to Defender's tab
        private int ruinPoints;
        private int stunningPoints;
        private int rushPoints;
        private int thornPoints;
        private int oneHandedPoints;
        private int slamPoints;
        private int comebackPoints;
        private int piercingPoints;
        private int rapidPoints;
        private int fortifyPoints;
        private int defenseMasteryPoints;
        private int chaoticPoints;
        private int massivePoints;
        private int bastionPoints;
        private int stonePoints;
        private int shieldPoints;
        private int steelPoints;
        private int eshoutPoints;
        private int resiliancePoints;
        private int galePoints;
        private int evastrikePoints;
        private int vigilancePoints;
        private int dshoutPoints;
        private int threatenPoints;
        private int retributionPoints;

        // Variables local to Sorcerer's tab
        private int fireArrowPoints;
        private int rapidBlastPoints;
        private int iceThornsPoints;
        private int iceArrowPoints;
        private int analyticsPoints;
        private int magicMasteryPoints;
        private int impactPoints;
        private int meditationPoints;
        private int fireOrbPoints;
        private int iceBarrierPoints;
        private int iceOrbPoints;
        private int intricacyPoints;
        private int firePillarPoints;
        private int coldArmorPoints;
        private int epcrystalPoints;
        private int flameConcentrationPoints;
        private int meteorPoints;
        private int fireArmorPoints;
        private int coldWavePoints;
        private int harmonyPoints;
        private int crystalPoints;
        private int wisdomPoints;
        private int flameTornadoPoints;
        private int imbalancePoints;


        // Constructor
        public MainWindow()
        {
            ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));
            PhysicalDamageReduction = 0;
            MagicDamageReduction = 0;
            InitializeComponent();
            ResetAllSkillTrees();
        }

        // Properties for additional variables
        // START
        public int PhysicalDamageReduction
        {
            get
            {
                return physicalDamageReduction;
            }
            set
            {
                if (physicalDamageReduction != value)
                {
                    physicalDamageReduction = value;
                    NotifyPropertyChanged("PhysicalDamageReduction");
                }
            }
        }

        public int MagicDamageReduction
        {
            get
            {
                return magicDamageReduction;
            }
            set
            {
                if (magicDamageReduction != value)
                {
                    magicDamageReduction = value;
                    NotifyPropertyChanged("MagicDamageReduction");
                }
            }
        }
        // STOP

        // Properties for variables used in all tabs
        // START
        public string BaseSkillTree
        {
            get
            {
                return baseSkillTree;
            }
            set
            {
                if (baseSkillTree != value)
                {
                    baseSkillTree = value;
                }
            }
        }

        public int AllocatedSkillPoints
        {
            get
            {
                return allocatedSkillPoints;
            }
            set
            {
                if (allocatedSkillPoints != value)
                {
                    allocatedSkillPoints = value;
                    NotifyPropertyChanged("AllocatedSkillPoints");
                    if (allocatedSkillPoints == 0)
                    {
                        BaseSkillTree = "";
                    }
                    else if (allocatedSkillPoints == 1)
                    {
                        if (AssassinSkillPoints == 1)
                            BaseSkillTree = "Assassin";
                        else if (BerserkerSkillPoints == 1)
                            BaseSkillTree = "Berserker";
                        else if (ClericSkillPoints == 1)
                            BaseSkillTree = "Cleric";
                        else if (DefenderSkillPoints == 1)
                            BaseSkillTree = "Defender";
                        else
                            BaseSkillTree = "Sorcerer";
                    }
                    else
                    {
                        if ((AssassinSkillPoints > BerserkerSkillPoints) &&
                            (AssassinSkillPoints > ClericSkillPoints) &&
                            (AssassinSkillPoints > DefenderSkillPoints) &&
                            (AssassinSkillPoints > SorcererSkillPoints))
                            BaseSkillTree = "Assassin";
                        else if ((BerserkerSkillPoints > AssassinSkillPoints) &&
                                (BerserkerSkillPoints > ClericSkillPoints) &&
                                (BerserkerSkillPoints > DefenderSkillPoints) &&
                                (BerserkerSkillPoints > SorcererSkillPoints))
                            BaseSkillTree = "Berserker";
                        else if ((ClericSkillPoints > AssassinSkillPoints) &&
                                (ClericSkillPoints > BerserkerSkillPoints) &&
                                (ClericSkillPoints > DefenderSkillPoints) &&
                                (ClericSkillPoints > SorcererSkillPoints))
                            BaseSkillTree = "Cleric";
                        else if ((DefenderSkillPoints > AssassinSkillPoints) &&
                                (DefenderSkillPoints > ClericSkillPoints) &&
                                (DefenderSkillPoints > BerserkerSkillPoints) &&
                                (DefenderSkillPoints > SorcererSkillPoints))
                            BaseSkillTree = "Defender";
                        else if ((SorcererSkillPoints > AssassinSkillPoints) &&
                                (SorcererSkillPoints > ClericSkillPoints) &&
                                (SorcererSkillPoints > DefenderSkillPoints) &&
                                (SorcererSkillPoints > BerserkerSkillPoints))
                            BaseSkillTree = "Sorcerer";
                    }
                }
            }
        }

        public int RemainingSkillPoints
        {
            get
            {
                return remainingSkillPoints;
            }
            set
            {
                if (remainingSkillPoints != value)
                {
                    remainingSkillPoints = value;
                    NotifyPropertyChanged("RemainingSkillPoints");
                }
            }
        }

        public int AssassinSkillPoints
        {
            get
            {
                return assassinSkillPoints;
            }
            set
            {
                if (assassinSkillPoints != value)
                {
                    assassinSkillPoints = value;
                    NotifyPropertyChanged("AssassinSkillPoints");
                }
                if (assassinSkillPoints < 5)
                {
                    DisableAssassinMastery();
                }
                else if (assassinSkillPoints == 5)
                {
                    PursuitLvl1.IsEnabled = true;
                    PushbackLvl1.IsEnabled = true;
                }
                else if (assassinSkillPoints == 10)
                {
                    CrossClassLvl1.IsEnabled = true;
                }
                else if (assassinSkillPoints == 15)
                {
                    RazorLvl1.IsEnabled = true;
                }
                else if (assassinSkillPoints == 20)
                {
                    ConcentrationLvl1.IsEnabled = true;
                }
                else if (assassinSkillPoints == 25)
                {
                    RazorLvl2.IsEnabled = true;
                }
                else if (assassinSkillPoints == 30)
                {
                    ConcentrationLvl2.IsEnabled = true;
                }
                else if (assassinSkillPoints == 35)
                {
                    RazorLvl3.IsEnabled = true;
                }
            }
        }

        public int BerserkerSkillPoints
        {
            get
            {
                return berserkerSkillPoints;
            }
            set
            {
                if (berserkerSkillPoints != value)
                {
                    berserkerSkillPoints = value;
                    NotifyPropertyChanged("BerserkerSkillPoints");
                }
                if (berserkerSkillPoints < 5)
                {
                    DisableBerserkerMastery();
                }
                else if (berserkerSkillPoints == 5)
                {
                    OutrageLvl1.IsEnabled = true;
                    ChainMasteryLvl1.IsEnabled = true;
                }
                else if (berserkerSkillPoints == 10)
                {
                    StyleMasteryLvl1.IsEnabled = true;
                }
                else if (berserkerSkillPoints == 15)
                {
                    PlateMasteryLvl1.IsEnabled = true;
                    ThirstLvl1.IsEnabled = true;
                }
                else if (berserkerSkillPoints == 20)
                {
                    SustainedLvl1.IsEnabled = true;
                }
                else if (berserkerSkillPoints == 25)
                {
                    ThirstLvl2.IsEnabled = true;
                }
                else if (berserkerSkillPoints == 30)
                {
                    SustainedLvl2.IsEnabled = true;
                }
                else if (berserkerSkillPoints == 35)
                {
                    ThirstLvl3.IsEnabled = true;
                }
            }
        }

        public int ClericSkillPoints
        {
            get
            {
                return clericSkillPoints;
            }
            set
            {
                if (clericSkillPoints != value)
                {
                    clericSkillPoints = value;
                    NotifyPropertyChanged("ClericSkillPoints");
                }
                if (clericSkillPoints < 5)
                {
                    DisableClericMastery();
                }
                else if (clericSkillPoints == 5)
                {
                    PossessLvl1.IsEnabled = true;
                    HealLvl1.IsEnabled = true;
                }
                else if (clericSkillPoints == 10)
                {
                    StyleMasteryClericLvl1.IsEnabled = true;
                }
                else if (clericSkillPoints == 15)
                {
                    ChainMasteryClericLvl1.IsEnabled = true;
                    HealLvl2.IsEnabled = true;
                }
                else if (clericSkillPoints == 20)
                {
                    HolyStrikingLvl1.IsEnabled = true;
                }
                else if (clericSkillPoints == 25)
                {
                    ResurrectLvl1.IsEnabled = true;
                    HealLvl3.IsEnabled = true;
                }
                else if (clericSkillPoints == 30)
                {
                    HolyStrikingLvl2.IsEnabled = true;
                }
                else if (clericSkillPoints == 35)
                {
                    ResurrectLvl2.IsEnabled = true;
                }
            }
        }

        public int DefenderSkillPoints
        {
            get
            {
                return defenderSkillPoints;
            }
            set
            {
                if (defenderSkillPoints != value)
                {
                    defenderSkillPoints = value;
                    NotifyPropertyChanged("DefenderSkillPoints");
                }
                if (defenderSkillPoints < 5)
                {
                    DisableDefenderMastery();
                }
                else if (defenderSkillPoints == 5)
                {
                    CounterattackLvl1.IsEnabled = true;
                    ChainMasteryDefLvl1.IsEnabled = true;
                }
                else if (defenderSkillPoints == 10)
                {
                    StyleMasteryDefLvl1.IsEnabled = true;
                }
                else if (defenderSkillPoints == 15)
                {
                    PlateMasteryDefLvl1.IsEnabled = true;
                    PhyTrainingLvl1.IsEnabled = true;
                }
                else if (defenderSkillPoints == 20)
                {
                    ExtendCounterLvl1.IsEnabled = true;
                }
                else if (defenderSkillPoints == 25)
                {
                    PhyTrainingLvl2.IsEnabled = true;
                }
                else if (defenderSkillPoints == 30)
                {
                    ExtendCounterLvl2.IsEnabled = true;
                }
                else if (defenderSkillPoints == 35)
                {
                    PhyTrainingLvl3.IsEnabled = true;
                }
            }
        }

        public int SorcererSkillPoints
        {
            get
            {
                return sorcererSkillPoints;
            }
            set
            {
                if (sorcererSkillPoints != value)
                {
                    sorcererSkillPoints = value;
                    NotifyPropertyChanged("SorcererSkillPoints");
                }
                if (sorcererSkillPoints < 5)
                {
                    DisableSorcererMastery();
                }
                else if (sorcererSkillPoints == 5)
                {
                    AwakeningLvl1.IsEnabled = true;
                }
                else if (sorcererSkillPoints == 10)
                {
                    StyleMasterySorcLvl1.IsEnabled = true;
                }
                else if (sorcererSkillPoints == 15)
                {
                    AffinityLvl1.IsEnabled = true;
                }
                else if (sorcererSkillPoints == 20)
                {
                    DynamicsLvl1.IsEnabled = true;
                }
                else if (sorcererSkillPoints == 25)
                {
                    AffinityLvl2.IsEnabled = true;
                }
                else if (sorcererSkillPoints == 30)
                {
                    DynamicsLvl2.IsEnabled = true;
                }
                else if (sorcererSkillPoints == 35)
                {
                    AffinityLvl3.IsEnabled = true;
                }
            }
        }
        // END
        // Properties for variables used in all tabs

        // Properties for variables local to Assassin's page
        // START
        public int ChaosPoints
        {
            get
            {
                return chaosPoints;
            }
            set
            {
                if (this.chaosPoints != value)
                {
                    this.chaosPoints = value;
                    this.NotifyPropertyChanged("ChaosPoints");
                }
            }
        }

        public int CleavePoints
        {
            get
            {
                return cleavePoints;
            }
            set
            {
                if (this.cleavePoints != value)
                {
                    this.cleavePoints = value;
                    this.NotifyPropertyChanged("CleavePoints");
                }
            }
        }

        public int CyclonePoints
        {
            get
            {
                return cyclonePoints;
            }
            set
            {
                if (this.cyclonePoints != value)
                {
                    this.cyclonePoints = value;
                    this.NotifyPropertyChanged("CyclonePoints");
                }
            }
        }

        public int EndurancePoints
        {
            get
            {
                return endurancePoints;
            }
            set
            {
                if (this.endurancePoints != value)
                {
                    this.endurancePoints = value;
                    this.NotifyPropertyChanged("EndurancePoints");
                }
            }
        }

        public int DaggerMasteryPoints
        {
            get
            {
                return daggermasteryPoints;
            }
            set
            {
                if (this.daggermasteryPoints != value)
                {
                    this.daggermasteryPoints = value;
                    this.NotifyPropertyChanged("DaggerMasteryPoints");
                }
            }
        }

        public int LeapPoints
        {
            get
            {
                return leapPoints;
            }
            set
            {
                if (this.leapPoints != value)
                {
                    this.leapPoints = value;
                    this.NotifyPropertyChanged("LeapPoints");
                }
            }
        }

        public int StabPoints
        {
            get
            {
                return stabPoints;
            }
            set
            {
                if (this.stabPoints != value)
                {
                    this.stabPoints = value;
                    this.NotifyPropertyChanged("StabPoints");
                }
            }
        }

        public int ResPoints
        {
            get
            {
                return resPoints;
            }
            set
            {
                if (this.resPoints != value)
                {
                    this.resPoints = value;
                    this.NotifyPropertyChanged("ResPoints");
                }
            }
        }

        public int StormPoints
        {
            get
            {
                return stormPoints;
            }
            set
            {
                if (this.stormPoints != value)
                {
                    this.stormPoints = value;
                    this.NotifyPropertyChanged("StormPoints");
                }
            }
        }

        public int PenePoints
        {
            get
            {
                return penePoints;
            }
            set
            {
                if (this.penePoints != value)
                {
                    this.penePoints = value;
                    this.NotifyPropertyChanged("PenePoints");
                }
            }
        }

        public int BlinkPoints
        {
            get
            {
                return blinkPoints;
            }
            set
            {
                if (this.blinkPoints != value)
                {
                    this.blinkPoints = value;
                    this.NotifyPropertyChanged("BlinkPoints");
                }
            }
        }

        public int AcrobaticsPoints
        {
            get
            {
                return acrobaticsPoints;
            }
            set
            {
                if (this.acrobaticsPoints != value)
                {
                    this.acrobaticsPoints = value;
                    this.NotifyPropertyChanged("AcrobaticsPoints");
                }
            }
        }

        public int BicyclePoints
        {
            get
            {
                return bicyclePoints;
            }
            set
            {
                if (this.bicyclePoints != value)
                {
                    this.bicyclePoints = value;
                    this.NotifyPropertyChanged("BicyclePoints");
                }
            }
        }

        public int VeilPoints
        {
            get
            {
                return veilPoints;
            }
            set
            {
                if (this.veilPoints != value)
                {
                    this.veilPoints = value;
                    this.NotifyPropertyChanged("VeilPoints");
                }
            }
        }

        public int AdrenPoints
        {
            get
            {
                return adrenPoints;
            }
            set
            {
                if (this.adrenPoints != value)
                {
                    this.adrenPoints = value;
                    this.NotifyPropertyChanged("AdrenPoints");
                }
            }
        }

        public int DragonPoints
        {
            get
            {
                return dragonPoints;
            }
            set
            {
                if (this.dragonPoints != value)
                {
                    this.dragonPoints = value;
                    this.NotifyPropertyChanged("DragonPoints");
                }
            }
        }

        public int WhirlPoints
        {
            get
            {
                return whirlPoints;
            }
            set
            {
                if (this.whirlPoints != value)
                {
                    this.whirlPoints = value;
                    this.NotifyPropertyChanged("WhirlPoints");
                }
            }
        }

        public int SeizePoints
        {
            get
            {
                return seizePoints;
            }
            set
            {
                if (this.seizePoints != value)
                {
                    this.seizePoints = value;
                    this.NotifyPropertyChanged("SeizePoints");
                }
            }
        }

        public int ShadowStrikePoints
        {
            get
            {
                return shadowstrikePoints;
            }
            set
            {
                if (this.shadowstrikePoints != value)
                {
                    this.shadowstrikePoints = value;
                    this.NotifyPropertyChanged("ShadowStrikePoints");
                }
            }
        }

        public int ShadowDancePoints
        {
            get
            {
                return shadowdancePoints;
            }
            set
            {
                if (this.shadowdancePoints != value)
                {
                    this.shadowdancePoints = value;
                    this.NotifyPropertyChanged("ShadowDancePoints");
                }
            }
        }

        public int FortPoints
        {
            get
            {
                return fortPoints;
            }
            set
            {
                if (this.fortPoints != value)
                {
                    this.fortPoints = value;
                    this.NotifyPropertyChanged("FortPoints");
                }
            }
        }

        public int BladeDancePoints
        {
            get
            {
                return bladedancePoints;
            }
            set
            {
                if (this.bladedancePoints != value)
                {
                    this.bladedancePoints = value;
                    this.NotifyPropertyChanged("BladeDancePoints");
                }
            }
        }

        public int InvigPoints
        {
            get
            {
                return invigPoints;
            }
            set
            {
                if (this.invigPoints != value)
                {
                    this.invigPoints = value;
                    this.NotifyPropertyChanged("InvigPoints");
                }
            }
        }

        public int ColdBloodedPoints
        {
            get
            {
                return coldbloodedPoints;
            }
            set
            {
                if (this.coldbloodedPoints != value)
                {
                    this.coldbloodedPoints = value;
                    this.NotifyPropertyChanged("ColdBloodedPoints");
                }
            }
        }
        // END
        // Properties for variables local to Assassin's page

        // Properties for variables local to Berserker's Page
        // START
        public int CrushPoints
        {
            get
            {
                return crushPoints;
            }
            set
            {
                if (this.crushPoints != value)
                {
                    this.crushPoints = value;
                    this.NotifyPropertyChanged("CrushPoints");
                }
            }
        }

        public int NeutralizePoints
        {
            get
            {
                return neutralizePoints;
            }
            set
            {
                if (this.neutralizePoints != value)
                {
                    this.neutralizePoints = value;
                    this.NotifyPropertyChanged("NeutralizePoints");
                }
            }
        }

        public int DodgePoints
        {
            get
            {
                return dodgePoints;
            }
            set
            {
                if (this.dodgePoints != value)
                {
                    this.dodgePoints = value;
                    this.NotifyPropertyChanged("DodgePoints");
                }
            }
        }

        public int NoMercyPoints
        {
            get
            {
                return noMercyPoints;
            }
            set
            {
                if (this.noMercyPoints != value)
                {
                    this.noMercyPoints = value;
                    this.NotifyPropertyChanged("NoMercyPoints");
                }
            }
        }

        public int TwoHandedPoints
        {
            get
            {
                return twoHandedPoints;
            }
            set
            {
                if (this.twoHandedPoints != value)
                {
                    this.twoHandedPoints = value;
                    this.NotifyPropertyChanged("TwoHandedPoints");
                }
            }
        }

        public int NocturnePoints
        {
            get
            {
                return nocturnePoints;
            }
            set
            {
                if (this.nocturnePoints != value)
                {
                    this.nocturnePoints = value;
                    this.NotifyPropertyChanged("NocturnePoints");
                }
            }
        }

        public int BerserkPoints
        {
            get
            {
                return berserkPoints;
            }
            set
            {
                if (this.berserkPoints != value)
                {
                    this.berserkPoints = value;
                    this.NotifyPropertyChanged("BerserkPoints");
                }
            }
        }

        public int BuffaloPoints
        {
            get
            {
                return buffaloPoints;
            }
            set
            {
                if (this.buffaloPoints != value)
                {
                    this.buffaloPoints = value;
                    this.NotifyPropertyChanged("BuffaloPoints");
                }
            }
        }

        public int FuriousPoints
        {
            get
            {
                return furiousPoints;
            }
            set
            {
                if (this.furiousPoints != value)
                {
                    this.furiousPoints = value;
                    this.NotifyPropertyChanged("FuriousPoints");
                }
            }
        }

        public int FeastPoints
        {
            get
            {
                return feastPoints;
            }
            set
            {
                if (this.feastPoints != value)
                {
                    this.feastPoints = value;
                    this.NotifyPropertyChanged("FeastPoints");
                }
            }
        }

        public int VanquishPoints
        {
            get
            {
                return vanquishPoints;
            }
            set
            {
                if (this.vanquishPoints != value)
                {
                    this.vanquishPoints = value;
                    this.NotifyPropertyChanged("VanquishPoints");
                }
            }
        }

        public int ArmageddonPoints
        {
            get
            {
                return armageddonPoints;
            }
            set
            {
                if (this.armageddonPoints != value)
                {
                    this.armageddonPoints = value;
                    this.NotifyPropertyChanged("ArmageddonPoints");
                }
            }
        }

        public int InertiaPoints
        {
            get
            {
                return inertiaPoints;
            }
            set
            {
                if (this.inertiaPoints != value)
                {
                    this.inertiaPoints = value;
                    this.NotifyPropertyChanged("InertiaPoints");
                }
            }
        }

        public int TranquilityPoints
        {
            get
            {
                return tranquilityPoints;
            }
            set
            {
                if (this.tranquilityPoints != value)
                {
                    this.tranquilityPoints = value;
                    this.NotifyPropertyChanged("TranquilityPoints");
                }
            }
        }

        public int CrueltyPoints
        {
            get
            {
                return crueltyPoints;
            }
            set
            {
                if (this.crueltyPoints != value)
                {
                    this.crueltyPoints = value;
                    this.NotifyPropertyChanged("CrueltyPoints");
                }
            }
        }

        public int BashPoints
        {
            get
            {
                return bashPoints;
            }
            set
            {
                if (this.bashPoints != value)
                {
                    this.bashPoints = value;
                    this.NotifyPropertyChanged("BashPoints");
                }
            }
        }

        public int ScamperPoints
        {
            get
            {
                return scamperPoints;
            }
            set
            {
                if (this.scamperPoints != value)
                {
                    this.scamperPoints = value;
                    this.NotifyPropertyChanged("ScamperPoints");
                }
            }
        }

        public int WoundsPoints
        {
            get
            {
                return woundsPoints;
            }
            set
            {
                if (this.woundsPoints != value)
                {
                    this.woundsPoints = value;
                    this.NotifyPropertyChanged("WoundsPoints");
                }
            }
        }

        public int UpwardPoints
        {
            get
            {
                return upwardPoints;
            }
            set
            {
                if (this.upwardPoints != value)
                {
                    this.upwardPoints = value;
                    this.NotifyPropertyChanged("UpwardPoints");
                }
            }
        }

        public int EscapePoints
        {
            get
            {
                return escapePoints;
            }
            set
            {
                if (this.escapePoints != value)
                {
                    this.escapePoints = value;
                    this.NotifyPropertyChanged("EscapePoints");
                }
            }
        }

        public int TornadoPoints
        {
            get
            {
                return tornadoPoints;
            }
            set
            {
                if (this.tornadoPoints != value)
                {
                    this.tornadoPoints = value;
                    this.NotifyPropertyChanged("TornadoPoints");
                }
            }
        }

        public int MadnessPoints
        {
            get
            {
                return madnessPoints;
            }
            set
            {
                if (this.madnessPoints != value)
                {
                    this.madnessPoints = value;
                    this.NotifyPropertyChanged("MadnessPoints");
                }
            }
        }

        public int ZerkBloodPoints
        {
            get
            {
                return zerkBloodPoints;
            }
            set
            {
                if (this.zerkBloodPoints != value)
                {
                    this.zerkBloodPoints = value;
                    this.NotifyPropertyChanged("ZerkBloodPoints");
                }
            }
        }
        // END
        // Properties for variables local to Berserker's Page

        // Properties for variables local to Cleric's Page
        // START
        public int LightPoints
        {
            get
            {
                return lightPoints;
            }
            set
            {
                if (this.lightPoints != value)
                {
                    this.lightPoints = value;
                    this.NotifyPropertyChanged("LightPoints");
                }
            }
        }

        public int DivinePoints
        {
            get
            {
                return divinePoints;
            }
            set
            {
                if (this.divinePoints != value)
                {
                    this.divinePoints = value;
                    this.NotifyPropertyChanged("DivinePoints");
                }
            }
        }

        public int RevitalizePoints
        {
            get
            {
                return revitalizePoints;
            }
            set
            {
                if (this.revitalizePoints != value)
                {
                    this.revitalizePoints = value;
                    this.NotifyPropertyChanged("RevitalizePoints");
                }
            }
        }

        public int RepercussionPoints
        {
            get
            {
                return repercussionPoints;
            }
            set
            {
                if (this.repercussionPoints != value)
                {
                    this.repercussionPoints = value;
                    this.NotifyPropertyChanged("RepercussionPoints");
                }
            }
        }

        public int DivineMasteryPoints
        {
            get
            {
                return divineMasteryPoints;
            }
            set
            {
                if (this.divineMasteryPoints != value)
                {
                    this.divineMasteryPoints = value;
                    this.NotifyPropertyChanged("DivineMasteryPoints");
                }
            }
        }

        public int FocusedPoints
        {
            get
            {
                return focusedPoints;
            }
            set
            {
                if (this.focusedPoints != value)
                {
                    this.focusedPoints = value;
                    this.NotifyPropertyChanged("FocusedPoints");
                }
            }
        }

        public int EnduranceBlessingPoints
        {
            get
            {
                return enduranceBlessingPoints;
            }
            set
            {
                if (this.enduranceBlessingPoints != value)
                {
                    this.enduranceBlessingPoints = value;
                    this.NotifyPropertyChanged("EnduranceBlessingPoints");
                }
            }
        }

        public int PleasurePoints
        {
            get
            {
                return pleasurePoints;
            }
            set
            {
                if (this.pleasurePoints != value)
                {
                    this.pleasurePoints = value;
                    this.NotifyPropertyChanged("PleasurePoints");
                }
            }
        }

        public int JudgePoints
        {
            get
            {
                return judgePoints;
            }
            set
            {
                if (this.judgePoints != value)
                {
                    this.judgePoints = value;
                    this.NotifyPropertyChanged("JudgePoints");
                }
            }
        }

        public int CopPoints
        {
            get
            {
                return copPoints;
            }
            set
            {
                if (this.copPoints != value)
                {
                    this.copPoints = value;
                    this.NotifyPropertyChanged("CopPoints");
                }
            }
        }

        public int CohPoints
        {
            get
            {
                return cohPoints;
            }
            set
            {
                if (this.cohPoints != value)
                {
                    this.cohPoints = value;
                    this.NotifyPropertyChanged("CohPoints");
                }
            }
        }

        public int MindTrainingPoints
        {
            get
            {
                return mindTrainingPoints;
            }
            set
            {
                if (this.mindTrainingPoints != value)
                {
                    this.mindTrainingPoints = value;
                    this.NotifyPropertyChanged("MindTrainingPoints");
                }
            }
        }

        public int HealingPoints
        {
            get
            {
                return healingPoints;
            }
            set
            {
                if (this.healingPoints != value)
                {
                    this.healingPoints = value;
                    this.NotifyPropertyChanged("HealingPoints");
                }
            }
        }

        public int DirePoints
        {
            get
            {
                return direPoints;
            }
            set
            {
                if (this.direPoints != value)
                {
                    this.direPoints = value;
                    this.NotifyPropertyChanged("DirePoints");
                }
            }
        }

        public int ConcentrationPoints
        {
            get
            {
                return concentrationPoints;
            }
            set
            {
                if (this.concentrationPoints != value)
                {
                    this.concentrationPoints = value;
                    this.NotifyPropertyChanged("ConcentrationPoints");
                }
            }
        }

        public int ArbitrationPoints
        {
            get
            {
                return arbitrationPoints;
            }
            set
            {
                if (this.arbitrationPoints != value)
                {
                    this.arbitrationPoints = value;
                    this.NotifyPropertyChanged("ArbitrationPoints");
                }
            }
        }

        public int LinksPoints
        {
            get
            {
                return linksPoints;
            }
            set
            {
                if (this.linksPoints != value)
                {
                    this.linksPoints = value;
                    this.NotifyPropertyChanged("LinksPoints");
                }
            }
        }

        public int RecoveryPoints
        {
            get
            {
                return recoveryPoints;
            }
            set
            {
                if (this.recoveryPoints != value)
                {
                    this.recoveryPoints = value;
                    this.NotifyPropertyChanged("RecoveryPoints");
                }
            }
        }

        public int OrbsPoints
        {
            get
            {
                return orbsPoints;
            }
            set
            {
                if (this.orbsPoints != value)
                {
                    this.orbsPoints = value;
                    this.NotifyPropertyChanged("OrbsPoints");
                }
            }
        }

        public int GoddessPoints
        {
            get
            {
                return goddessPoints;
            }
            set
            {
                if (this.goddessPoints != value)
                {
                    this.goddessPoints = value;
                    this.NotifyPropertyChanged("GoddessPoints");
                }
            }
        }

        public int UpliftPoints
        {
            get
            {
                return upliftPoints;
            }
            set
            {
                if (this.upliftPoints != value)
                {
                    this.upliftPoints = value;
                    this.NotifyPropertyChanged("UpliftPoints");
                }
            }
        }

        public int WhirlpoolPoints
        {
            get
            {
                return whirlpoolPoints;
            }
            set
            {
                if (this.whirlpoolPoints != value)
                {
                    this.whirlpoolPoints = value;
                    this.NotifyPropertyChanged("WhirlpoolPoints");
                }
            }
        }

        public int SalvationPoints
        {
            get
            {
                return salvationPoints;
            }
            set
            {
                if (this.salvationPoints != value)
                {
                    this.salvationPoints = value;
                    this.NotifyPropertyChanged("SalvationPoints");
                }
            }
        }

        public int SwiftnessPoints
        {
            get
            {
                return swiftnessPoints;
            }
            set
            {
                if (this.swiftnessPoints != value)
                {
                    this.swiftnessPoints = value;
                    this.NotifyPropertyChanged("SwiftnessPoints");
                }
            }
        }

        public int PriestPoints
        {
            get
            {
                return priestPoints;
            }
            set
            {
                if (this.priestPoints != value)
                {
                    this.priestPoints = value;
                    this.NotifyPropertyChanged("PriestPoints");
                }
            }
        }

        public int StormJudgementPoints
        {
            get
            {
                return stormJudgementPoints;
            }
            set
            {
                if (this.stormJudgementPoints != value)
                {
                    this.stormJudgementPoints = value;
                    this.NotifyPropertyChanged("StormJudgementPoints");
                }
            }
        }

        public int NimblePoints
        {
            get
            {
                return nimblePoints;
            }
            set
            {
                if (this.nimblePoints != value)
                {
                    this.nimblePoints = value;
                    this.NotifyPropertyChanged("NimblePoints");
                }
            }
        }
        // END
        // Properties for variables local to Cleric's Page

        // Properties for variables local to Defender's Page
        // START
        public int RuinPoints
        {
            get
            {
                return ruinPoints;
            }
            set
            {
                if (this.ruinPoints != value)
                {
                    this.ruinPoints = value;
                    this.NotifyPropertyChanged("RuinPoints");
                }
            }
        }

        public int StunningPoints
        {
            get
            {
                return stunningPoints;
            }
            set
            {
                if (this.stunningPoints != value)
                {
                    this.stunningPoints = value;
                    this.NotifyPropertyChanged("StunningPoints");
                }
            }
        }

        public int RushPoints
        {
            get
            {
                return rushPoints;
            }
            set
            {
                if (this.rushPoints != value)
                {
                    this.rushPoints = value;
                    this.NotifyPropertyChanged("RushPoints");
                }
            }
        }

        public int ThornPoints
        {
            get
            {
                return thornPoints;
            }
            set
            {
                if (this.thornPoints != value)
                {
                    this.thornPoints = value;
                    this.NotifyPropertyChanged("ThornPoints");
                }
            }
        }

        public int OneHandedPoints
        {
            get
            {
                return oneHandedPoints;
            }
            set
            {
                if (this.oneHandedPoints != value)
                {
                    this.oneHandedPoints = value;
                    this.NotifyPropertyChanged("OneHandedPoints");
                }
            }
        }

        public int SlamPoints
        {
            get
            {
                return slamPoints;
            }
            set
            {
                if (this.slamPoints != value)
                {
                    this.slamPoints = value;
                    this.NotifyPropertyChanged("SlamPoints");
                }
            }
        }

        public int ComebackPoints
        {
            get
            {
                return comebackPoints;
            }
            set
            {
                if (this.comebackPoints != value)
                {
                    this.comebackPoints = value;
                    this.NotifyPropertyChanged("ComebackPoints");
                }
            }
        }

        public int PiercingPoints
        {
            get
            {
                return piercingPoints;
            }
            set
            {
                if (this.piercingPoints != value)
                {
                    this.piercingPoints = value;
                    this.NotifyPropertyChanged("PiercingPoints");
                }
            }
        }

        public int RapidPoints
        {
            get
            {
                return rapidPoints;
            }
            set
            {
                if (this.rapidPoints != value)
                {
                    this.rapidPoints = value;
                    this.NotifyPropertyChanged("RapidPoints");
                }
            }
        }

        public int FortifyPoints
        {
            get
            {
                return fortifyPoints;
            }
            set
            {
                if (this.fortifyPoints != value)
                {
                    this.fortifyPoints = value;
                    this.NotifyPropertyChanged("FortifyPoints");
                }
            }
        }

        public int DefenseMasteryPoints
        {
            get
            {
                return defenseMasteryPoints;
            }
            set
            {
                if (this.defenseMasteryPoints != value)
                {
                    this.defenseMasteryPoints = value;
                    this.NotifyPropertyChanged("DefenseMasteryPoints");
                }
            }
        }

        public int ChaoticPoints
        {
            get
            {
                return chaoticPoints;
            }
            set
            {
                if (this.chaoticPoints != value)
                {
                    this.chaoticPoints = value;
                    this.NotifyPropertyChanged("ChaoticPoints");
                }
            }
        }

        public int MassivePoints
        {
            get
            {
                return massivePoints;
            }
            set
            {
                if (this.massivePoints != value)
                {
                    this.massivePoints = value;
                    this.NotifyPropertyChanged("MassivePoints");
                }
            }
        }

        public int BastionPoints
        {
            get
            {
                return bastionPoints;
            }
            set
            {
                if (this.bastionPoints != value)
                {
                    this.bastionPoints = value;
                    this.NotifyPropertyChanged("BastionPoints");
                }
            }
        }

        public int StonePoints
        {
            get
            {
                return stonePoints;
            }
            set
            {
                if (this.stonePoints != value)
                {
                    this.stonePoints = value;
                    this.NotifyPropertyChanged("StonePoints");
                }
            }
        }

        public int ShieldPoints
        {
            get
            {
                return shieldPoints;
            }
            set
            {
                if (this.shieldPoints != value)
                {
                    this.shieldPoints = value;
                    this.NotifyPropertyChanged("ShieldPoints");
                }
            }
        }

        public int SteelPoints
        {
            get
            {
                return steelPoints;
            }
            set
            {
                if (this.steelPoints != value)
                {
                    this.steelPoints = value;
                    this.NotifyPropertyChanged("SteelPoints");
                }
            }
        }

        public int EshoutPoints
        {
            get
            {
                return eshoutPoints;
            }
            set
            {
                if (this.eshoutPoints != value)
                {
                    this.eshoutPoints = value;
                    this.NotifyPropertyChanged("EshoutPoints");
                }
            }
        }

        public int ResiliancePoints
        {
            get
            {
                return resiliancePoints;
            }
            set
            {
                if (this.resiliancePoints != value)
                {
                    this.resiliancePoints = value;
                    this.NotifyPropertyChanged("ResiliancePoints");
                }
            }
        }

        public int GalePoints
        {
            get
            {
                return galePoints;
            }
            set
            {
                if (this.galePoints != value)
                {
                    this.galePoints = value;
                    this.NotifyPropertyChanged("GalePoints");
                }
            }
        }

        public int EvastrikePoints
        {
            get
            {
                return evastrikePoints;
            }
            set
            {
                if (this.evastrikePoints != value)
                {
                    this.evastrikePoints = value;
                    this.NotifyPropertyChanged("EvastrikePoints");
                }
            }
        }

        public int VigilancePoints
        {
            get
            {
                return vigilancePoints;
            }
            set
            {
                if (this.vigilancePoints != value)
                {
                    this.vigilancePoints = value;
                    this.NotifyPropertyChanged("VigilancePoints");
                }
            }
        }

        public int DshoutPoints
        {
            get
            {
                return dshoutPoints;
            }
            set
            {
                if (this.dshoutPoints != value)
                {
                    this.dshoutPoints = value;
                    this.NotifyPropertyChanged("DshoutPoints");
                }
            }
        }

        public int ThreatenPoints
        {
            get
            {
                return threatenPoints;
            }
            set
            {
                if (this.threatenPoints != value)
                {
                    this.threatenPoints = value;
                    this.NotifyPropertyChanged("ThreatenPoints");
                }
            }
        }

        public int RetributionPoints
        {
            get
            {
                return retributionPoints;
            }
            set
            {
                if (this.retributionPoints != value)
                {
                    this.retributionPoints = value;
                    this.NotifyPropertyChanged("RetributionPoints");
                }
            }
        }
        // END
        // Properties for variables local to Defender's Page

        // Properties for variables local to Sorcerer's Page
        // START
        public int FireArrowPoints
        {
            get
            {
                return fireArrowPoints;
            }
            set
            {
                if (this.fireArrowPoints != value)
                {
                    this.fireArrowPoints = value;
                    this.NotifyPropertyChanged("FireArrowPoints");
                }
            }
        }

        public int RapidBlastPoints
        {
            get
            {
                return rapidBlastPoints;
            }
            set
            {
                if (this.rapidBlastPoints != value)
                {
                    this.rapidBlastPoints = value;
                    this.NotifyPropertyChanged("RapidBlastPoints");
                }
            }
        }

        public int IceThornsPoints
        {
            get
            {
                return iceThornsPoints;
            }
            set
            {
                if (this.iceThornsPoints != value)
                {
                    this.iceThornsPoints = value;
                    this.NotifyPropertyChanged("IceThornsPoints");
                }
            }
        }

        public int IceArrowPoints
        {
            get
            {
                return iceArrowPoints;
            }
            set
            {
                if (this.iceArrowPoints != value)
                {
                    this.iceArrowPoints = value;
                    this.NotifyPropertyChanged("IceArrowPoints");
                }
            }
        }

        public int AnalyticsPoints
        {
            get
            {
                return analyticsPoints;
            }
            set
            {
                if (this.analyticsPoints != value)
                {
                    this.analyticsPoints = value;
                    this.NotifyPropertyChanged("AnalyticsPoints");
                }
            }
        }

        public int MagicMasteryPoints
        {
            get
            {
                return magicMasteryPoints;
            }
            set
            {
                if (this.magicMasteryPoints != value)
                {
                    this.magicMasteryPoints = value;
                    this.NotifyPropertyChanged("MagicMasteryPoints");
                }
            }
        }

        public int ImpactPoints
        {
            get
            {
                return impactPoints;
            }
            set
            {
                if (this.impactPoints != value)
                {
                    this.impactPoints = value;
                    this.NotifyPropertyChanged("ImpactPoints");
                }
            }
        }

        public int MeditationPoints
        {
            get
            {
                return meditationPoints;
            }
            set
            {
                if (this.meditationPoints != value)
                {
                    this.meditationPoints = value;
                    this.NotifyPropertyChanged("MeditationPoints");
                }
            }
        }

        public int FireOrbPoints
        {
            get
            {
                return fireOrbPoints;
            }
            set
            {
                if (this.fireOrbPoints != value)
                {
                    this.fireOrbPoints = value;
                    this.NotifyPropertyChanged("FireOrbPoints");
                }
            }
        }

        public int IceBarrierPoints
        {
            get
            {
                return iceBarrierPoints;
            }
            set
            {
                if (this.iceBarrierPoints != value)
                {
                    this.iceBarrierPoints = value;
                    this.NotifyPropertyChanged("IceBarrierPoints");
                }
            }
        }

        public int IceOrbPoints
        {
            get
            {
                return iceOrbPoints;
            }
            set
            {
                if (this.iceOrbPoints != value)
                {
                    this.iceOrbPoints = value;
                    this.NotifyPropertyChanged("IceOrbPoints");
                }
            }
        }

        public int IntricacyPoints
        {
            get
            {
                return intricacyPoints;
            }
            set
            {
                if (this.intricacyPoints != value)
                {
                    this.intricacyPoints = value;
                    this.NotifyPropertyChanged("IntricacyPoints");
                }
            }
        }

        public int FirePillarPoints
        {
            get
            {
                return firePillarPoints;
            }
            set
            {
                if (this.firePillarPoints != value)
                {
                    this.firePillarPoints = value;
                    this.NotifyPropertyChanged("FirePillarPoints");
                }
            }
        }

        public int ColdArmorPoints
        {
            get
            {
                return coldArmorPoints;
            }
            set
            {
                if (this.coldArmorPoints != value)
                {
                    this.coldArmorPoints = value;
                    this.NotifyPropertyChanged("ColdArmorPoints");
                }
            }
        }

        public int EpcrystalPoints
        {
            get
            {
                return epcrystalPoints;
            }
            set
            {
                if (this.epcrystalPoints != value)
                {
                    this.epcrystalPoints = value;
                    this.NotifyPropertyChanged("EpcrystalPoints");
                }
            }
        }

        public int FlameConcentrationPoints
        {
            get
            {
                return flameConcentrationPoints;
            }
            set
            {
                if (this.flameConcentrationPoints != value)
                {
                    this.flameConcentrationPoints = value;
                    this.NotifyPropertyChanged("FlameConcentrationPoints");
                }
            }
        }

        public int MeteorPoints
        {
            get
            {
                return meteorPoints;
            }
            set
            {
                if (this.meteorPoints != value)
                {
                    this.meteorPoints = value;
                    this.NotifyPropertyChanged("MeteorPoints");
                }
            }
        }

        public int FireArmorPoints
        {
            get
            {
                return fireArmorPoints;
            }
            set
            {
                if (this.fireArmorPoints != value)
                {
                    this.fireArmorPoints = value;
                    this.NotifyPropertyChanged("FireArmorPoints");
                }
            }
        }

        public int ColdWavePoints
        {
            get
            {
                return coldWavePoints;
            }
            set
            {
                if (this.coldWavePoints != value)
                {
                    this.coldWavePoints = value;
                    this.NotifyPropertyChanged("ColdWavePoints");
                }
            }
        }

        public int HarmonyPoints
        {
            get
            {
                return harmonyPoints;
            }
            set
            {
                if (this.harmonyPoints != value)
                {
                    this.harmonyPoints = value;
                    this.NotifyPropertyChanged("HarmonyPoints");
                }
            }
        }

        public int CrystalPoints
        {
            get
            {
                return crystalPoints;
            }
            set
            {
                if (this.crystalPoints != value)
                {
                    this.crystalPoints = value;
                    this.NotifyPropertyChanged("CrystalPoints");
                }
            }
        }

        public int WisdomPoints
        {
            get
            {
                return wisdomPoints;
            }
            set
            {
                if (this.wisdomPoints != value)
                {
                    this.wisdomPoints = value;
                    this.NotifyPropertyChanged("WisdomPoints");
                }
            }
        }

        public int FlameTornadoPoints
        {
            get
            {
                return flameTornadoPoints;
            }
            set
            {
                if (this.flameTornadoPoints != value)
                {
                    this.flameTornadoPoints = value;
                    this.NotifyPropertyChanged("FlameTornadoPoints");
                }
            }
        }

        public int ImbalancePoints
        {
            get
            {
                return imbalancePoints;
            }
            set
            {
                if (this.imbalancePoints != value)
                {
                    this.imbalancePoints = value;
                    this.NotifyPropertyChanged("ImbalancePoints");
                }
            }
        }
        // END
        // Properties for variables local to Sorcerer's Page

        // Local methods
        // START

        // Reset all points
        public void ResetAllPoints()
        {
            ResetGlobalTabPoints();

            ResetAssassinTabPoints();

            ResetBerserkerTabPoints();

            ResetClericTabPoints();

            ResetDefenderTabPoints();

            ResetSorcererTabPoints();
        }

        // Global Tab
        public void ResetGlobalTabPoints()
        {
            BaseSkillTree = "";
            AllocatedSkillPoints = 0;
            RemainingSkillPoints = MaxSkillPoints;
            AssassinSkillPoints = 0;
            BerserkerSkillPoints = 0;
            ClericSkillPoints = 0;
            DefenderSkillPoints = 0;
            SorcererSkillPoints = 0;
        }

        // Assassin Tab
        public void ResetAssassinTabPoints()
        {
            ChaosPoints = 0;
            CleavePoints = 0;
            CyclonePoints = 0;
            EndurancePoints = 0;
            DaggerMasteryPoints = 0;
            LeapPoints = 0;
            StabPoints = 0;
            ResPoints = 0;
            StormPoints = 0;
            PenePoints = 0;
            BlinkPoints = 0;
            AcrobaticsPoints = 0;
            BicyclePoints = 0;
            VeilPoints = 0;
            AdrenPoints = 0;
            DragonPoints = 0;
            WhirlPoints = 0;
            SeizePoints = 0;
            ShadowStrikePoints = 0;
            ShadowDancePoints = 0;
            FortPoints = 0;
            BladeDancePoints = 0;
            InvigPoints = 0;
            ColdBloodedPoints = 0;
        }

        // Berserker Tab
        public void ResetBerserkerTabPoints()
        {
            CrushPoints = 0;
            NeutralizePoints = 0;
            DodgePoints = 0;
            NoMercyPoints = 0;
            TwoHandedPoints = 0;
            NocturnePoints = 0;
            BerserkPoints = 0;
            BuffaloPoints = 0;
            FuriousPoints = 0;
            FeastPoints = 0;
            VanquishPoints = 0;
            ArmageddonPoints = 0;
            InertiaPoints = 0;
            TranquilityPoints = 0;
            CrueltyPoints = 0;
            BashPoints = 0;
            ScamperPoints = 0;
            WoundsPoints = 0;
            UpwardPoints = 0;
            EscapePoints = 0;
            TornadoPoints = 0;
            MadnessPoints = 0;
            ZerkBloodPoints = 0;
        }

        // Cleric Tab
        public void ResetClericTabPoints()
        {
            LightPoints = 0;
            DivinePoints = 0;
            RevitalizePoints = 0;
            RepercussionPoints = 0;
            DivineMasteryPoints = 0;
            FocusedPoints = 0;
            EnduranceBlessingPoints = 0;
            PleasurePoints = 0;
            JudgePoints = 0;
            CopPoints = 0;
            CohPoints = 0;
            MindTrainingPoints = 0;
            HealingPoints = 0;
            DirePoints = 0;
            ConcentrationPoints = 0;
            ArbitrationPoints = 0;
            LinksPoints = 0;
            RecoveryPoints = 0;
            OrbsPoints = 0;
            GoddessPoints = 0;
            UpliftPoints = 0;
            WhirlpoolPoints = 0;
            SalvationPoints = 0;
            SwiftnessPoints = 0;
            PriestPoints = 0;
            StormJudgementPoints = 0;
            NimblePoints = 0;
        }

        // Defender Tab
        public void ResetDefenderTabPoints()
        {
            RuinPoints = 0;
            StunningPoints = 0;
            RushPoints = 0;
            ThornPoints = 0;
            OneHandedPoints = 0;
            SlamPoints = 0;
            ComebackPoints = 0;
            PiercingPoints = 0;
            RapidPoints = 0;
            FortifyPoints = 0;
            DefenseMasteryPoints = 0;
            ChaoticPoints = 0;
            MassivePoints = 0;
            BastionPoints = 0;
            StonePoints = 0;
            ShieldPoints = 0;
            SteelPoints = 0;
            EshoutPoints = 0;
            ResiliancePoints = 0;
            GalePoints = 0;
            EvastrikePoints = 0;
            VigilancePoints = 0;
            DshoutPoints = 0;
            ThreatenPoints = 0;
            RetributionPoints = 0;
        }

        // Sorcerer Tab
        public void ResetSorcererTabPoints()
        {
            FireArrowPoints = 0;
            RapidBlastPoints = 0;
            IceThornsPoints = 0;
            IceArrowPoints = 0;
            AnalyticsPoints = 0;
            MagicMasteryPoints = 0;
            ImpactPoints = 0;
            MeditationPoints = 0;
            FireOrbPoints = 0;
            IceBarrierPoints = 0;
            IceOrbPoints = 0;
            IntricacyPoints = 0;
            FirePillarPoints = 0;
            ColdArmorPoints = 0;
            EpcrystalPoints = 0;
            FlameConcentrationPoints = 0;
            MeteorPoints = 0;
            FireArmorPoints = 0;
            ColdWavePoints = 0;
            HarmonyPoints = 0;
            CrystalPoints = 0;
            WisdomPoints = 0;
            FlameTornadoPoints = 0;
            ImbalancePoints = 0;
        }

        // Reset all Skill Trees
        public void ResetAllSkillTrees()
        {
            // Set all skill points to zero (and ste remaining points to maximum skill points allowed)
            ResetAllPoints();

            // Disable all skill buttons once
            DisableAllSkillButtons();

            // Enable appropriate skill buttons accordingly now
            UpdateSkillsAvailability();

            // Reset damage reductions
            UpdateDamageReductions();
        }

        public void DisableAllSkillButtons()
        {
            // Disable assassin tree buttons
            DisableAssassinTreeButtons();

            // Disable berserker tree buttons
            DisableBerserkerTreeButtons();

            // Disable cleric tree buttons
            DisableClericTreeButtons();

            // Disable defender tree buttons
            DisableDefenderTreeButtons();

            // Disable sorcerer tree buttons
            DisableSorcererTreeButtons();
        }

        public void DisableAssassinTreeButtons()
        {
            ChaosButton.IsEnabled = false;
            CleaveButton.IsEnabled = false;
            CycloneButton.IsEnabled = false;
            EnduranceButton.IsEnabled = false;
            DaggerMasteryButton.IsEnabled = false;
            LeapButton.IsEnabled = false;
            StabButton.IsEnabled = false;
            ResButton.IsEnabled = false;
            StormButton.IsEnabled = false;
            PeneButton.IsEnabled = false;
            BlinkButton.IsEnabled = false;
            AcrobaticsButton.IsEnabled = false;
            BicycleButton.IsEnabled = false;
            VeilButton.IsEnabled = false;
            AdrenButton.IsEnabled = false;
            DragonButton.IsEnabled = false;
            WhirlButton.IsEnabled = false;
            SeizeButton.IsEnabled = false;
            ShadowStrikeButton.IsEnabled = false;
            ShadowDanceButton.IsEnabled = false;
            FortButton.IsEnabled = false;
            BladeDanceButton.IsEnabled = false;
            InvigButton.IsEnabled = false;
            ColdBloodedButton.IsEnabled = false;
        }

        public void DisableBerserkerTreeButtons()
        {
            CrushButton.IsEnabled = false;
            NeutralizeButton.IsEnabled = false;
            DodgeButton.IsEnabled = false;
            NoMercyButton.IsEnabled = false;
            TwoHandedButton.IsEnabled = false;
            NocturneButton.IsEnabled = false;
            BerserkButton.IsEnabled = false;
            BuffaloButton.IsEnabled = false;
            FuriousButton.IsEnabled = false;
            FeastButton.IsEnabled = false;
            VanquishButton.IsEnabled = false;
            ArmageddonButton.IsEnabled = false;
            InertiaButton.IsEnabled = false;
            TranquilityButton.IsEnabled = false;
            CrueltyButton.IsEnabled = false;
            BashButton.IsEnabled = false;
            ScamperButton.IsEnabled = false;
            WoundsButton.IsEnabled = false;
            UpwardButton.IsEnabled = false;
            EscapeButton.IsEnabled = false;
            TornadoButton.IsEnabled = false;
            MadnessButton.IsEnabled = false;
            ZerkBloodButton.IsEnabled = false;
        }

        public void DisableClericTreeButtons()
        {
            LightButton.IsEnabled = false;
            DivineButton.IsEnabled = false;
            RevitalizeButton.IsEnabled = false;
            RepercussionButton.IsEnabled = false;
            DivineMasteryButton.IsEnabled = false;
            FocusedButton.IsEnabled = false;
            EnduranceBlessingButton.IsEnabled = false;
            PleasureButton.IsEnabled = false;
            JudgeButton.IsEnabled = false;
            CopButton.IsEnabled = false;
            CohButton.IsEnabled = false;
            MindTrainingButton.IsEnabled = false;
            HealingButton.IsEnabled = false;
            DireButton.IsEnabled = false;
            ConcentrationButton.IsEnabled = false;
            ArbitrationButton.IsEnabled = false;
            LinksButton.IsEnabled = false;
            RecoveryButton.IsEnabled = false;
            OrbsButton.IsEnabled = false;
            GoddessButton.IsEnabled = false;
            UpliftButton.IsEnabled = false;
            WhirlpoolButton.IsEnabled = false;
            SalvationButton.IsEnabled = false;
            SwiftnessButton.IsEnabled = false;
            PriestButton.IsEnabled = false;
            StormJudgementButton.IsEnabled = false;
            NimbleButton.IsEnabled = false;
        }

        public void DisableDefenderTreeButtons()
        {
            RuinButton.IsEnabled = false;
            StunningButton.IsEnabled = false;
            RushButton.IsEnabled = false;
            ThornButton.IsEnabled = false;
            OneHandedButton.IsEnabled = false;
            SlamButton.IsEnabled = false;
            ComebackButton.IsEnabled = false;
            PiercingButton.IsEnabled = false;
            RapidButton.IsEnabled = false;
            FortifyButton.IsEnabled = false;
            DefenseMasteryButton.IsEnabled = false;
            ChaoticButton.IsEnabled = false;
            MassiveButton.IsEnabled = false;
            BastionButton.IsEnabled = false;
            StoneButton.IsEnabled = false;
            ShieldButton.IsEnabled = false;
            SteelButton.IsEnabled = false;
            EshoutButton.IsEnabled = false;
            ResilianceButton.IsEnabled = false;
            GaleButton.IsEnabled = false;
            EvastrikeButton.IsEnabled = false;
            VigilanceButton.IsEnabled = false;
            DshoutButton.IsEnabled = false;
            ThreatenButton.IsEnabled = false;
            RetributionButton.IsEnabled = false;
        }

        public void DisableSorcererTreeButtons()
        {
            FireArrowButton.IsEnabled = false;
            RapidBlastButton.IsEnabled = false;
            IceThornsButton.IsEnabled = false;
            IceArrowButton.IsEnabled = false;
            AnalyticsButton.IsEnabled = false;
            MagicMasteryButton.IsEnabled = false;
            ImpactButton.IsEnabled = false;
            MeditationButton.IsEnabled = false;
            FireOrbButton.IsEnabled = false;
            IceBarrierButton.IsEnabled = false;
            IceOrbButton.IsEnabled = false;
            IntricacyButton.IsEnabled = false;
            FirePillarButton.IsEnabled = false;
            ColdArmorButton.IsEnabled = false;
            EpcrystalButton.IsEnabled = false;
            FlameConcentrationButton.IsEnabled = false;
            MeteorButton.IsEnabled = false;
            FireArmorButton.IsEnabled = false;
            ColdWaveButton.IsEnabled = false;
            HarmonyButton.IsEnabled = false;
            CrystalButton.IsEnabled = false;
            WisdomButton.IsEnabled = false;
            FlameTornadoButton.IsEnabled = false;
            ImbalanceButton.IsEnabled = false;
        }

        // Update skill availability for all trees
        public void UpdateSkillsAvailability()
        {
            if (AllocatedSkillPoints == 0)
            {
                Enable1stRowAssassinTree();
                Enable1stRowBerserkerTree();
                Enable1stRowClericTree();
                Enable1stRowDefenderTree();
                Enable1stRowSorcererTree();
            }
            else if ((AllocatedSkillPoints > 0) && (AllocatedSkillPoints < 10))
            {
                if (BaseSkillTree == "Assassin")
                {
                    UpdateAssassinTree();
                    DisableBerserkerTreeButtons();
                    DisableClericTreeButtons();
                    DisableDefenderTreeButtons();
                    DisableSorcererTreeButtons();
                }
                else if (BaseSkillTree == "Berserker")
                {
                    UpdateBerserkerTree();
                    DisableAssassinTreeButtons();
                    DisableClericTreeButtons();
                    DisableDefenderTreeButtons();
                    DisableSorcererTreeButtons();
                }
                else if (BaseSkillTree == "Cleric")
                {
                    UpdateClericTree();
                    DisableAssassinTreeButtons();
                    DisableBerserkerTreeButtons();
                    DisableDefenderTreeButtons();
                    DisableSorcererTreeButtons();
                }
                else if (BaseSkillTree == "Defender")
                {
                    UpdateDefenderTree();
                    DisableAssassinTreeButtons();
                    DisableBerserkerTreeButtons();
                    DisableClericTreeButtons();
                    DisableSorcererTreeButtons();
                }
                else if (BaseSkillTree == "Sorcerer")
                {
                    UpdateSorcererTree();
                    DisableAssassinTreeButtons();
                    DisableBerserkerTreeButtons();
                    DisableClericTreeButtons();
                    DisableDefenderTreeButtons();
                }
                else
                {
                    MessageBox.Show("Incorrect Base Tree", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    App.Current.Shutdown();
                }
            }
            else if ((AllocatedSkillPoints >= 10) && (AllocatedSkillPoints < MaxSkillPoints))
            {
                UpdateAssassinTree();
                UpdateBerserkerTree();
                UpdateClericTree();
                UpdateDefenderTree();
                UpdateSorcererTree();
            }
            else if (AllocatedSkillPoints == MaxSkillPoints)
            {
                DisableAllSkillButtons();
            }
            else
            {
                MessageBox.Show("Allocated Skill Points exceeded Max Allowed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.Shutdown();
            }
        }

        public void Enable1stRowAssassinTree()
        {
            ChaosButton.IsEnabled = true;
            CleaveButton.IsEnabled = true;
            // CycloneButton.IsEnabled = true;
            EnduranceButton.IsEnabled = true;
            DaggerMasteryButton.IsEnabled = true;
        }

        public void Enable1stRowBerserkerTree()
        {
            CrushButton.IsEnabled = true;
            NeutralizeButton.IsEnabled = true;
            // DodgeButton.IsEnabled = true;
            NoMercyButton.IsEnabled = true;
            TwoHandedButton.IsEnabled = true;
        }

        public void Enable1stRowClericTree()
        {
            LightButton.IsEnabled = true;
            DivineButton.IsEnabled = true;
            RevitalizeButton.IsEnabled = true;
            RepercussionButton.IsEnabled = true;
            DivineMasteryButton.IsEnabled = true;
        }

        public void Enable1stRowDefenderTree()
        {
            RuinButton.IsEnabled = true;
            StunningButton.IsEnabled = true;
            RushButton.IsEnabled = true;
            ThornButton.IsEnabled = true;
            OneHandedButton.IsEnabled = true;
        }

        public void Enable1stRowSorcererTree()
        {
            FireArrowButton.IsEnabled = true;
            RapidBlastButton.IsEnabled = true;
            IceThornsButton.IsEnabled = true;
            IceArrowButton.IsEnabled = true;
            AnalyticsButton.IsEnabled = true;
            MagicMasteryButton.IsEnabled = true;
        }

        public void UpdateAssassinTree()
        {
            // Update chaos stinger button
            switch (ChaosPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 0)
                        ChaosButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 5)
                        ChaosButton.IsEnabled = true;
                    else
                        ChaosButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 10)
                        ChaosButton.IsEnabled = true;
                    else
                        ChaosButton.IsEnabled = false;
                    break;
                case 3:
                    ChaosButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Update cleave button
            switch (CleavePoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 0)
                        CleaveButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 5)
                        CleaveButton.IsEnabled = true;
                    else
                        CleaveButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 10)
                        CleaveButton.IsEnabled = true;
                    else
                        CleaveButton.IsEnabled = false;
                    break;
                case 3:
                    CleaveButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Update cyclone kick button
            if (CleavePoints >= 1)
            {
                switch (CyclonePoints)
                {
                    case 0:
                        if (AssassinSkillPoints >= 0)
                            CycloneButton.IsEnabled = true;
                        break;
                    case 1:
                        if (AssassinSkillPoints >= 5)
                            CycloneButton.IsEnabled = true;
                        else
                            CycloneButton.IsEnabled = false;
                        break;
                    case 2:
                        if (AssassinSkillPoints >= 10)
                            CycloneButton.IsEnabled = true;
                        else
                            CycloneButton.IsEnabled = false;
                        break;
                    case 3:
                        if (AssassinSkillPoints >= 15)
                            CycloneButton.IsEnabled = true;
                        else
                            CycloneButton.IsEnabled = false;
                        break;
                    case 4:
                        if (AssassinSkillPoints >= 20)
                            CycloneButton.IsEnabled = true;
                        else
                            CycloneButton.IsEnabled = false;
                        break;
                    case 5:
                        CycloneButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            // Update dagger mastery button
            if (AssassinSkillPoints >= 0)
            {
                DaggerMasteryButton.IsEnabled = true;
                if (DaggerMasteryPoints == 5)
                {
                    DaggerMasteryButton.IsEnabled = false;
                }
            }

            // Update endurance button
            if (AssassinSkillPoints >= 0)
            {
                EnduranceButton.IsEnabled = true;
                if (EndurancePoints == 3)
                {
                    EnduranceButton.IsEnabled = false;
                }
            }

            // Update dragonic leap button
            switch (LeapPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 5)
                        LeapButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 10)
                        LeapButton.IsEnabled = true;
                    else
                        LeapButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 15)
                        LeapButton.IsEnabled = true;
                    else
                        LeapButton.IsEnabled = false;
                    break;
                case 3:
                    if (AssassinSkillPoints >= 20)
                        LeapButton.IsEnabled = true;
                    else
                        LeapButton.IsEnabled = false;
                    break;
                case 4:
                    if (AssassinSkillPoints >= 25)
                        LeapButton.IsEnabled = true;
                    else
                        LeapButton.IsEnabled = false;
                    break;
                case 5:
                    LeapButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Update fatal stab button
            switch (StabPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 5)
                        StabButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 10)
                        StabButton.IsEnabled = true;
                    else
                        StabButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 15)
                        StabButton.IsEnabled = true;
                    else
                        StabButton.IsEnabled = false;
                    break;
                case 3:
                    StabButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Update restorative elixir button
            switch (ResPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 5)
                        ResButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 10)
                        ResButton.IsEnabled = true;
                    else
                        ResButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 15)
                        ResButton.IsEnabled = true;
                    else
                        ResButton.IsEnabled = false;
                    break;
                case 3:
                    ResButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Update storm blades button
            if (ChaosPoints >= 1)
            {
                switch (StormPoints)
                {
                    case 0:
                        if (AssassinSkillPoints >= 10)
                            StormButton.IsEnabled = true;
                        break;
                    case 1:
                        if (AssassinSkillPoints >= 15)
                            StormButton.IsEnabled = true;
                        else
                            StormButton.IsEnabled = false;
                        break;
                    case 2:
                        if (AssassinSkillPoints >= 20)
                            StormButton.IsEnabled = true;
                        else
                            StormButton.IsEnabled = false;
                        break;
                    case 3:
                        StormButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            // Penetration stinger
            switch (PenePoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 10)
                        PeneButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 15)
                        PeneButton.IsEnabled = true;
                    else
                        PeneButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 20)
                        PeneButton.IsEnabled = true;
                    else
                        PeneButton.IsEnabled = false;
                    break;
                case 3:
                    PeneButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Shadow walk
            switch (BlinkPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 10)
                        BlinkButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 15)
                        BlinkButton.IsEnabled = true;
                    else
                        BlinkButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 20)
                        BlinkButton.IsEnabled = true;
                    else
                        BlinkButton.IsEnabled = false;
                    break;
                case 3:
                    BlinkButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Acrobatics
            if (AssassinSkillPoints >= 10)
            {
                AcrobaticsButton.IsEnabled = true;
                if (AcrobaticsPoints == 3)
                {
                    AcrobaticsButton.IsEnabled = false;
                }
            }

            // Bicycle
            switch (BicyclePoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 15)
                        BicycleButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 20)
                        BicycleButton.IsEnabled = true;
                    else
                        BicycleButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 25)
                        BicycleButton.IsEnabled = true;
                    else
                        BicycleButton.IsEnabled = false;
                    break;
                case 3:
                    BicycleButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Veil of darkness
            switch (VeilPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 15)
                        VeilButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 20)
                        VeilButton.IsEnabled = true;
                    else
                        VeilButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 25)
                        VeilButton.IsEnabled = true;
                    else
                        VeilButton.IsEnabled = false;
                    break;
                case 3:
                    VeilButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // adrenaline elixir
            switch (AdrenPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 15)
                        AdrenButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 20)
                        AdrenButton.IsEnabled = true;
                    else
                        AdrenButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 25)
                        AdrenButton.IsEnabled = true;
                    else
                        AdrenButton.IsEnabled = false;
                    break;
                case 3:
                    AdrenButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Rising dragon
            if (StormPoints >= 1)
            {
                switch (DragonPoints)
                {
                    case 0:
                        if (AssassinSkillPoints >= 20)
                            DragonButton.IsEnabled = true;
                        break;
                    case 1:
                        if (AssassinSkillPoints >= 25)
                            DragonButton.IsEnabled = true;
                        else
                            DragonButton.IsEnabled = false;
                        break;
                    case 2:
                        if (AssassinSkillPoints >= 30)
                            DragonButton.IsEnabled = true;
                        else
                            DragonButton.IsEnabled = false;
                        break;
                    case 3:
                        if (AssassinSkillPoints >= 35)
                            DragonButton.IsEnabled = true;
                        else
                            DragonButton.IsEnabled = false;
                        break;
                    case 4:
                        if (AssassinSkillPoints >= 40)
                            DragonButton.IsEnabled = true;
                        else
                            DragonButton.IsEnabled = false;
                        break;
                    case 5:
                        DragonButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            // Whirling blade
            if (PenePoints >= 1)
            {
                switch (WhirlPoints)
                {
                    case 0:
                        if (AssassinSkillPoints >= 20)
                            WhirlButton.IsEnabled = true;
                        break;
                    case 1:
                        if (AssassinSkillPoints >= 25)
                            WhirlButton.IsEnabled = true;
                        else
                            WhirlButton.IsEnabled = false;
                        break;
                    case 2:
                        if (AssassinSkillPoints >= 30)
                            WhirlButton.IsEnabled = true;
                        else
                            WhirlButton.IsEnabled = false;
                        break;
                    case 3:
                        WhirlButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            // Seize the moment
            if (AssassinSkillPoints >= 20)
            {
                SeizeButton.IsEnabled = true;
                if (SeizePoints == 3)
                    SeizeButton.IsEnabled = false;
            }

            // Shadow strike
            switch (ShadowStrikePoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 25)
                        ShadowStrikeButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 30)
                        ShadowStrikeButton.IsEnabled = true;
                    else
                        ShadowStrikeButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 35)
                        ShadowStrikeButton.IsEnabled = true;
                    else
                        ShadowStrikeButton.IsEnabled = false;
                    break;
                case 3:
                    ShadowStrikeButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Shadow dance
            if (AssassinSkillPoints >= 25)
            {
                ShadowDanceButton.IsEnabled = true;
                if (ShadowDancePoints == 1)
                    ShadowDanceButton.IsEnabled = false;
            }

            // Fortifying elixir
            if (AdrenPoints >= 1)
            {
                switch (FortPoints)
                {
                    case 0:
                        if (AssassinSkillPoints >= 25)
                            FortButton.IsEnabled = true;
                        break;
                    case 1:
                        if (AssassinSkillPoints >= 30)
                            FortButton.IsEnabled = true;
                        else
                            FortButton.IsEnabled = false;
                        break;
                    case 2:
                        if (AssassinSkillPoints >= 35)
                            FortButton.IsEnabled = true;
                        else
                            FortButton.IsEnabled = false;
                        break;
                    case 3:
                        FortButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            // Blade dance
            switch (BladeDancePoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 30)
                        BladeDanceButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 35)
                        BladeDanceButton.IsEnabled = true;
                    else
                        BladeDanceButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 40)
                        BladeDanceButton.IsEnabled = true;
                    else
                        BladeDanceButton.IsEnabled = false;
                    break;
                case 3:
                    BladeDanceButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Invigoration
            switch (InvigPoints)
            {
                case 0:
                    if (AssassinSkillPoints >= 30)
                        InvigButton.IsEnabled = true;
                    break;
                case 1:
                    if (AssassinSkillPoints >= 35)
                        InvigButton.IsEnabled = true;
                    else
                        InvigButton.IsEnabled = false;
                    break;
                case 2:
                    if (AssassinSkillPoints >= 40)
                        InvigButton.IsEnabled = true;
                    else
                        InvigButton.IsEnabled = false;
                    break;
                case 3:
                    InvigButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            // Cold blooded
            if (AssassinSkillPoints >= 30)
            {
                ColdBloodedButton.IsEnabled = true;
                if (ColdBloodedPoints == 3)
                {
                    ColdBloodedButton.IsEnabled = false;
                }
            }
        }

        public void UpdateBerserkerTree()
        {
            switch (CrushPoints)
            {
                case 0:
                    if (BerserkerSkillPoints >= 0)
                        CrushButton.IsEnabled = true;
                    break;
                case 1:
                    if (BerserkerSkillPoints >= 5)
                        CrushButton.IsEnabled = true;
                    else
                        CrushButton.IsEnabled = false;
                    break;
                case 2:
                    if (BerserkerSkillPoints >= 10)
                        CrushButton.IsEnabled = true;
                    else
                        CrushButton.IsEnabled = false;
                    break;
                case 3:
                    if (BerserkerSkillPoints >= 15)
                        CrushButton.IsEnabled = true;
                    else
                        CrushButton.IsEnabled = false;
                    break;
                case 4:
                    if (BerserkerSkillPoints >= 20)
                        CrushButton.IsEnabled = true;
                    else
                        CrushButton.IsEnabled = false;
                    break;
                case 5:
                    CrushButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (NeutralizePoints)
            {
                case 0:
                    if (BerserkerSkillPoints >= 0)
                        NeutralizeButton.IsEnabled = true;
                    break;
                case 1:
                    if (BerserkerSkillPoints >= 5)
                        NeutralizeButton.IsEnabled = true;
                    else
                        NeutralizeButton.IsEnabled = false;
                    break;
                case 2:
                    if (BerserkerSkillPoints >= 10)
                        NeutralizeButton.IsEnabled = true;
                    else
                        NeutralizeButton.IsEnabled = false;
                    break;
                case 3:
                    NeutralizeButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (NeutralizePoints >= 1)
            {
                switch (DodgePoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 0)
                            DodgeButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 5)
                            DodgeButton.IsEnabled = true;
                        else
                            DodgeButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 10)
                            DodgeButton.IsEnabled = true;
                        else
                            DodgeButton.IsEnabled = false;
                        break;
                    case 3:
                        DodgeButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (BerserkerSkillPoints >= 0)
            {
                TwoHandedButton.IsEnabled = true;
                if (TwoHandedPoints == 5)
                    TwoHandedButton.IsEnabled = false;
            }

            if (BerserkerSkillPoints >= 0)
            {
                NoMercyButton.IsEnabled = true;
                if (NoMercyPoints == 5)
                    NoMercyButton.IsEnabled = false;
            }

            switch (NocturnePoints)
            {
                case 0:
                    if (BerserkerSkillPoints >= 5)
                        NocturneButton.IsEnabled = true;
                    break;
                case 1:
                    if (BerserkerSkillPoints >= 10)
                        NocturneButton.IsEnabled = true;
                    else
                        NocturneButton.IsEnabled = false;
                    break;
                case 2:
                    if (BerserkerSkillPoints >= 15)
                        NocturneButton.IsEnabled = true;
                    else
                        NocturneButton.IsEnabled = false;
                    break;
                case 3:
                    if (BerserkerSkillPoints >= 20)
                        NocturneButton.IsEnabled = true;
                    else
                        NocturneButton.IsEnabled = false;
                    break;
                case 4:
                    if (BerserkerSkillPoints >= 25)
                        NocturneButton.IsEnabled = true;
                    else
                        NocturneButton.IsEnabled = false;
                    break;
                case 5:
                    NocturneButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (BerserkPoints)
            {
                case 0:
                    if (BerserkerSkillPoints >= 5)
                        BerserkButton.IsEnabled = true;
                    break;
                case 1:
                    if (BerserkerSkillPoints >= 10)
                        BerserkButton.IsEnabled = true;
                    else
                        BerserkButton.IsEnabled = false;
                    break;
                case 2:
                    if (BerserkerSkillPoints >= 15)
                        BerserkButton.IsEnabled = true;
                    else
                        BerserkButton.IsEnabled = false;
                    break;
                case 3:
                    BerserkButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (BuffaloPoints)
            {
                case 0:
                    if (BerserkerSkillPoints >= 10)
                        BuffaloButton.IsEnabled = true;
                    break;
                case 1:
                    if (BerserkerSkillPoints >= 15)
                        BuffaloButton.IsEnabled = true;
                    else
                        BuffaloButton.IsEnabled = false;
                    break;
                case 2:
                    if (BerserkerSkillPoints >= 20)
                        BuffaloButton.IsEnabled = true;
                    else
                        BuffaloButton.IsEnabled = false;
                    break;
                case 3:
                    if (BerserkerSkillPoints >= 25)
                        BuffaloButton.IsEnabled = true;
                    else
                        BuffaloButton.IsEnabled = false;
                    break;
                case 4:
                    if (BerserkerSkillPoints >= 30)
                        BuffaloButton.IsEnabled = true;
                    else
                        BuffaloButton.IsEnabled = false;
                    break;
                case 5:
                    BuffaloButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (BerserkPoints >= 1)
            {
                switch (FuriousPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 10)
                            FuriousButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 15)
                            FuriousButton.IsEnabled = true;
                        else
                            FuriousButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 20)
                            FuriousButton.IsEnabled = true;
                        else
                            FuriousButton.IsEnabled = false;
                        break;
                    case 3:
                        FuriousButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (BerserkerSkillPoints >= 10)
            {
                FeastButton.IsEnabled = true;
                if (FeastPoints == 2)
                    FeastButton.IsEnabled = false;
            }

            if (CrushPoints >= 1)
            {
                switch (VanquishPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 15)
                            VanquishButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 20)
                            VanquishButton.IsEnabled = true;
                        else
                            VanquishButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 25)
                            VanquishButton.IsEnabled = true;
                        else
                            VanquishButton.IsEnabled = false;
                        break;
                    case 3:
                        if (BerserkerSkillPoints >= 30)
                            VanquishButton.IsEnabled = true;
                        else
                            VanquishButton.IsEnabled = false;
                        break;
                    case 4:
                        if (BerserkerSkillPoints >= 35)
                            VanquishButton.IsEnabled = true;
                        else
                            VanquishButton.IsEnabled = false;
                        break;
                    case 5:
                        VanquishButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (DodgePoints >= 1)
            {
                switch (ArmageddonPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 15)
                            ArmageddonButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 20)
                            ArmageddonButton.IsEnabled = true;
                        else
                            ArmageddonButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 25)
                            ArmageddonButton.IsEnabled = true;
                        else
                            ArmageddonButton.IsEnabled = false;
                        break;
                    case 3:
                        if (BerserkerSkillPoints >= 30)
                            ArmageddonButton.IsEnabled = true;
                        else
                            ArmageddonButton.IsEnabled = false;
                        break;
                    case 4:
                        if (BerserkerSkillPoints >= 35)
                            ArmageddonButton.IsEnabled = true;
                        else
                            ArmageddonButton.IsEnabled = false;
                        break;
                    case 5:
                        ArmageddonButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (FuriousPoints >= 1)
            {
                switch (InertiaPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 15)
                            InertiaButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 20)
                            InertiaButton.IsEnabled = true;
                        else
                            InertiaButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 25)
                            InertiaButton.IsEnabled = true;
                        else
                            InertiaButton.IsEnabled = false;
                        break;
                    case 3:
                        InertiaButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (BerserkPoints >= 1)
            {
                switch (TranquilityPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 15)
                            TranquilityButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 20)
                            TranquilityButton.IsEnabled = true;
                        else
                            TranquilityButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 25)
                            TranquilityButton.IsEnabled = true;
                        else
                            TranquilityButton.IsEnabled = false;
                        break;
                    case 3:
                        TranquilityButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (BerserkerSkillPoints >= 15)
            {
                CrueltyButton.IsEnabled = true;
                if (CrueltyPoints == 2)
                    CrueltyButton.IsEnabled = false;
            }

            switch (BashPoints)
            {
                case 0:
                    if (BerserkerSkillPoints >= 20)
                        BashButton.IsEnabled = true;
                    break;
                case 1:
                    if (BerserkerSkillPoints >= 25)
                        BashButton.IsEnabled = true;
                    else
                        BashButton.IsEnabled = false;
                    break;
                case 2:
                    if (BerserkerSkillPoints >= 30)
                        BashButton.IsEnabled = true;
                    else
                        BashButton.IsEnabled = false;
                    break;
                case 3:
                    BashButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (InertiaPoints >= 1)
            {
                switch (ScamperPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 20)
                            ScamperButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 25)
                            ScamperButton.IsEnabled = true;
                        else
                            ScamperButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 30)
                            ScamperButton.IsEnabled = true;
                        else
                            ScamperButton.IsEnabled = false;
                        break;
                    case 3:
                        ScamperButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (BerserkerSkillPoints >= 20)
            {
                WoundsButton.IsEnabled = true;
                if (WoundsPoints == 2)
                    WoundsButton.IsEnabled = false;
            }

            if (VanquishPoints >= 1)
            {
                switch (UpwardPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 25)
                            UpwardButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 30)
                            UpwardButton.IsEnabled = true;
                        else
                            UpwardButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 35)
                            UpwardButton.IsEnabled = true;
                        else
                            UpwardButton.IsEnabled = false;
                        break;
                    case 3:
                        UpwardButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (BerserkerSkillPoints >= 25)
            {
                EscapeButton.IsEnabled = true;
                if (EscapePoints == 2)
                    EscapeButton.IsEnabled = false;
            }

            switch (TornadoPoints)
            {
                case 0:
                    if (BerserkerSkillPoints >= 30)
                        TornadoButton.IsEnabled = true;
                    break;
                case 1:
                    if (BerserkerSkillPoints >= 35)
                        TornadoButton.IsEnabled = true;
                    else
                        TornadoButton.IsEnabled = false;
                    break;
                case 2:
                    if (BerserkerSkillPoints >= 40)
                        TornadoButton.IsEnabled = true;
                    else
                        TornadoButton.IsEnabled = false;
                    break;
                case 3:
                    TornadoButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (TranquilityPoints >= 1)
            {
                switch (MadnessPoints)
                {
                    case 0:
                        if (BerserkerSkillPoints >= 30)
                            MadnessButton.IsEnabled = true;
                        break;
                    case 1:
                        if (BerserkerSkillPoints >= 35)
                            MadnessButton.IsEnabled = true;
                        else
                            MadnessButton.IsEnabled = false;
                        break;
                    case 2:
                        if (BerserkerSkillPoints >= 40)
                            MadnessButton.IsEnabled = true;
                        else
                            MadnessButton.IsEnabled = false;
                        break;
                    case 3:
                        MadnessButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (BerserkerSkillPoints >= 30)
            {
                ZerkBloodButton.IsEnabled = true;
                if (ZerkBloodPoints == 3)
                    ZerkBloodButton.IsEnabled = false;
            }
        }

        public void UpdateClericTree()
        {
            switch (LightPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 0)
                        LightButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 5)
                        LightButton.IsEnabled = true;
                    else
                        LightButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 10)
                        LightButton.IsEnabled = true;
                    else
                        LightButton.IsEnabled = false;
                    break;
                case 3:
                    LightButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (DivinePoints)
            {
                case 0:
                    if (ClericSkillPoints >= 0)
                        DivineButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 5)
                        DivineButton.IsEnabled = true;
                    else
                        DivineButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 10)
                        DivineButton.IsEnabled = true;
                    else
                        DivineButton.IsEnabled = false;
                    break;
                case 3:
                    if (ClericSkillPoints >= 15)
                        DivineButton.IsEnabled = true;
                    else
                        DivineButton.IsEnabled = false;
                    break;
                case 4:
                    if (ClericSkillPoints >= 20)
                        DivineButton.IsEnabled = true;
                    else
                        DivineButton.IsEnabled = false;
                    break;
                case 5:
                    DivineButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (RevitalizePoints)
            {
                case 0:
                    if (ClericSkillPoints >= 0)
                        RevitalizeButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 5)
                        RevitalizeButton.IsEnabled = true;
                    else
                        RevitalizeButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 10)
                        RevitalizeButton.IsEnabled = true;
                    else
                        RevitalizeButton.IsEnabled = false;
                    break;
                case 3:
                    RevitalizeButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (ClericSkillPoints >= 0)
            {
                RepercussionButton.IsEnabled = true;
                if (RepercussionPoints == 3)
                    RepercussionButton.IsEnabled = false;
            }

            if (ClericSkillPoints >= 0)
            {
                DivineMasteryButton.IsEnabled = true;
                if (DivineMasteryPoints == 5)
                    DivineMasteryButton.IsEnabled = false;
            }

            switch (FocusedPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 5)
                        FocusedButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 10)
                        FocusedButton.IsEnabled = true;
                    else
                        FocusedButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 15)
                        FocusedButton.IsEnabled = true;
                    else
                        FocusedButton.IsEnabled = false;
                    break;
                case 3:
                    FocusedButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (EnduranceBlessingPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 5)
                        EnduranceBlessingButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 10)
                        EnduranceBlessingButton.IsEnabled = true;
                    else
                        EnduranceBlessingButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 15)
                        EnduranceBlessingButton.IsEnabled = true;
                    else
                        EnduranceBlessingButton.IsEnabled = false;
                    break;
                case 3:
                    EnduranceBlessingButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (ClericSkillPoints >= 5)
            {
                PleasureButton.IsEnabled = true;
                if (PleasurePoints == 2)
                    PleasureButton.IsEnabled = false;
            }

            if (LightPoints >= 1)
            {
                switch (JudgePoints)
                {
                    case 0:
                        if (ClericSkillPoints >= 10)
                            JudgeButton.IsEnabled = true;
                        break;
                    case 1:
                        if (ClericSkillPoints >= 15)
                            JudgeButton.IsEnabled = true;
                        else
                            JudgeButton.IsEnabled = false;
                        break;
                    case 2:
                        if (ClericSkillPoints >= 20)
                            JudgeButton.IsEnabled = true;
                        else
                            JudgeButton.IsEnabled = false;
                        break;
                    case 3:
                        JudgeButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (DivinePoints >= 1)
            {
                switch (CopPoints)
                {
                    case 0:
                        if (ClericSkillPoints >= 10)
                            CopButton.IsEnabled = true;
                        break;
                    case 1:
                        if (ClericSkillPoints >= 15)
                            CopButton.IsEnabled = true;
                        else
                            CopButton.IsEnabled = false;
                        break;
                    case 2:
                        if (ClericSkillPoints >= 20)
                            CopButton.IsEnabled = true;
                        else
                            CopButton.IsEnabled = false;
                        break;
                    case 3:
                        if (ClericSkillPoints >= 25)
                            CopButton.IsEnabled = true;
                        else
                            CopButton.IsEnabled = false;
                        break;
                    case 4:
                        if (ClericSkillPoints >= 30)
                            CopButton.IsEnabled = true;
                        else
                            CopButton.IsEnabled = false;
                        break;
                    case 5:
                        CopButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (RevitalizePoints >= 1)
            {
                switch (CohPoints)
                {
                    case 0:
                        if (ClericSkillPoints >= 10)
                            CohButton.IsEnabled = true;
                        break;
                    case 1:
                        if (ClericSkillPoints >= 15)
                            CohButton.IsEnabled = true;
                        else
                            CohButton.IsEnabled = false;
                        break;
                    case 2:
                        if (ClericSkillPoints >= 20)
                            CohButton.IsEnabled = true;
                        else
                            CohButton.IsEnabled = false;
                        break;
                    case 3:
                        CohButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (ClericSkillPoints >= 10)
            {
                MindTrainingButton.IsEnabled = true;
                if (MindTrainingPoints == 3)
                    MindTrainingButton.IsEnabled = false;
            }

            if (FocusedPoints >= 1)
            {
                switch (HealingPoints)
                {
                    case 0:
                        if (ClericSkillPoints >= 15)
                            HealingButton.IsEnabled = true;
                        break;
                    case 1:
                        if (ClericSkillPoints >= 20)
                            HealingButton.IsEnabled = true;
                        else
                            HealingButton.IsEnabled = false;
                        break;
                    case 2:
                        if (ClericSkillPoints >= 25)
                            HealingButton.IsEnabled = true;
                        else
                            HealingButton.IsEnabled = false;
                        break;
                    case 3:
                        HealingButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (DirePoints)
            {
                case 0:
                    if (ClericSkillPoints >= 15)
                        DireButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 20)
                        DireButton.IsEnabled = true;
                    else
                        DireButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 25)
                        DireButton.IsEnabled = true;
                    else
                        DireButton.IsEnabled = false;
                    break;
                case 3:
                    DireButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (ConcentrationPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 15)
                        ConcentrationButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 20)
                        ConcentrationButton.IsEnabled = true;
                    else
                        ConcentrationButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 25)
                        ConcentrationButton.IsEnabled = true;
                    else
                        ConcentrationButton.IsEnabled = false;
                    break;
                case 3:
                    ConcentrationButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (ClericSkillPoints >= 15)
            {
                ArbitrationButton.IsEnabled = true;
                if (ArbitrationPoints == 3)
                    ArbitrationButton.IsEnabled = false;
            }

            if (JudgePoints >= 1)
            {
                switch (LinksPoints)
                {
                    case 0:
                        if (ClericSkillPoints >= 20)
                            LinksButton.IsEnabled = true;
                        break;
                    case 1:
                        if (ClericSkillPoints >= 25)
                            LinksButton.IsEnabled = true;
                        else
                            LinksButton.IsEnabled = false;
                        break;
                    case 2:
                        if (ClericSkillPoints >= 30)
                            LinksButton.IsEnabled = true;
                        else
                            LinksButton.IsEnabled = false;
                        break;
                    case 3:
                        LinksButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (RecoveryPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 20)
                        RecoveryButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 25)
                        RecoveryButton.IsEnabled = true;
                    else
                        RecoveryButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 30)
                        RecoveryButton.IsEnabled = true;
                    else
                        RecoveryButton.IsEnabled = false;
                    break;
                case 3:
                    RecoveryButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (OrbsPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 20)
                        OrbsButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 25)
                        OrbsButton.IsEnabled = true;
                    else
                        OrbsButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 30)
                        OrbsButton.IsEnabled = true;
                    else
                        OrbsButton.IsEnabled = false;
                    break;
                case 3:
                    OrbsButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (DirePoints >= 1)
            {
                switch (GoddessPoints)
                {
                    case 0:
                        if (ClericSkillPoints >= 20)
                            GoddessButton.IsEnabled = true;
                        break;
                    case 1:
                        if (ClericSkillPoints >= 25)
                            GoddessButton.IsEnabled = true;
                        else
                            GoddessButton.IsEnabled = false;
                        break;
                    case 2:
                        GoddessButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (ClericSkillPoints >= 20)
            {
                UpliftButton.IsEnabled = true;
                if (UpliftPoints == 3)
                    UpliftButton.IsEnabled = false;
            }

            if (ClericSkillPoints >= 25)
            {
                WhirlpoolButton.IsEnabled = true;
                if (WhirlpoolPoints == 1)
                    WhirlpoolButton.IsEnabled = false;
            }

            switch (SalvationPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 25)
                        SalvationButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 30)
                        SalvationButton.IsEnabled = true;
                    else
                        SalvationButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 35)
                        SalvationButton.IsEnabled = true;
                    else
                        SalvationButton.IsEnabled = false;
                    break;
                case 3:
                    SalvationButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (SwiftnessPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 25)
                        SwiftnessButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 30)
                        SwiftnessButton.IsEnabled = true;
                    else
                        SwiftnessButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 35)
                        SwiftnessButton.IsEnabled = true;
                    else
                        SwiftnessButton.IsEnabled = false;
                    break;
                case 3:
                    SwiftnessButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (ClericSkillPoints >= 25)
            {
                PriestButton.IsEnabled = true;
                if (PriestPoints == 3)
                    PriestButton.IsEnabled = false;
            }

            switch (StormJudgementPoints)
            {
                case 0:
                    if (ClericSkillPoints >= 30)
                        StormJudgementButton.IsEnabled = true;
                    break;
                case 1:
                    if (ClericSkillPoints >= 35)
                        StormJudgementButton.IsEnabled = true;
                    else
                        StormJudgementButton.IsEnabled = false;
                    break;
                case 2:
                    if (ClericSkillPoints >= 40)
                        StormJudgementButton.IsEnabled = true;
                    else
                        StormJudgementButton.IsEnabled = false;
                    break;
                case 3:
                    StormJudgementButton.IsEnabled = false;
                    break;
                default:
                    break;
            }


            if (ClericSkillPoints >= 30)
            {
                NimbleButton.IsEnabled = true;
                if (NimblePoints == 2)
                    NimbleButton.IsEnabled = false;
            }
        }

        public void UpdateDefenderTree()
        {
            switch (RuinPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 0)
                        RuinButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 5)
                        RuinButton.IsEnabled = true;
                    else
                        RuinButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 10)
                        RuinButton.IsEnabled = true;
                    else
                        RuinButton.IsEnabled = false;
                    break;
                case 3:
                    RuinButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (StunningPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 0)
                        StunningButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 5)
                        StunningButton.IsEnabled = true;
                    else
                        StunningButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 10)
                        StunningButton.IsEnabled = true;
                    else
                        StunningButton.IsEnabled = false;
                    break;
                case 3:
                    if (DefenderSkillPoints >= 15)
                        StunningButton.IsEnabled = true;
                    else
                        StunningButton.IsEnabled = false;
                    break;
                case 4:
                    if (DefenderSkillPoints >= 20)
                        StunningButton.IsEnabled = true;
                    else
                        StunningButton.IsEnabled = false;
                    break;
                case 5:
                    StunningButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (RushPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 0)
                        RushButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 5)
                        RushButton.IsEnabled = true;
                    else
                        RushButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 10)
                        RushButton.IsEnabled = true;
                    else
                        RushButton.IsEnabled = false;
                    break;
                case 3:
                    RushButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (DefenderSkillPoints >= 0)
            {
                ThornButton.IsEnabled = true;
                if (ThornPoints == 3)
                    ThornButton.IsEnabled = false;
            }

            if (DefenderSkillPoints >= 0)
            {
                OneHandedButton.IsEnabled = true;
                if (OneHandedPoints == 5)
                    OneHandedButton.IsEnabled = false;
            }

            if (RushPoints >= 1)
            {
                switch (SlamPoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 5)
                            SlamButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 10)
                            SlamButton.IsEnabled = true;
                        else
                            SlamButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 15)
                            SlamButton.IsEnabled = true;
                        else
                            SlamButton.IsEnabled = false;
                        break;
                    case 3:
                        if (DefenderSkillPoints >= 20)
                            SlamButton.IsEnabled = true;
                        else
                            SlamButton.IsEnabled = false;
                        break;
                    case 4:
                        if (DefenderSkillPoints >= 25)
                            SlamButton.IsEnabled = true;
                        else
                            SlamButton.IsEnabled = false;
                        break;
                    case 5:
                        SlamButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (ComebackPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 5)
                        ComebackButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 10)
                        ComebackButton.IsEnabled = true;
                    else
                        ComebackButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 15)
                        ComebackButton.IsEnabled = true;
                    else
                        ComebackButton.IsEnabled = false;
                    break;
                case 3:
                    ComebackButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (PiercingPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 10)
                        PiercingButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 15)
                        PiercingButton.IsEnabled = true;
                    else
                        PiercingButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 20)
                        PiercingButton.IsEnabled = true;
                    else
                        PiercingButton.IsEnabled = false;
                    break;
                case 3:
                    PiercingButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (StunningPoints >= 1)
            {
                switch (RapidPoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 10)
                            RapidButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 15)
                            RapidButton.IsEnabled = true;
                        else
                            RapidButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 20)
                            RapidButton.IsEnabled = true;
                        else
                            RapidButton.IsEnabled = false;
                        break;
                    case 3:
                        RapidButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (FortifyPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 10)
                        FortifyButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 15)
                        FortifyButton.IsEnabled = true;
                    else
                        FortifyButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 15)
                        FortifyButton.IsEnabled = true;
                    else
                        FortifyButton.IsEnabled = false;
                    break;
                case 3:
                    FortifyButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (DefenderSkillPoints >= 10)
            {
                DefenseMasteryButton.IsEnabled = true;
                if (DefenseMasteryPoints == 3)
                    DefenseMasteryButton.IsEnabled = false;
            }

            if (PiercingPoints >= 1)
            {
                switch (ChaoticPoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 15)
                            ChaoticButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 20)
                            ChaoticButton.IsEnabled = true;
                        else
                            ChaoticButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 25)
                            ChaoticButton.IsEnabled = true;
                        else
                            ChaoticButton.IsEnabled = false;
                        break;
                    case 3:
                        ChaoticButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (SlamPoints >= 1)
            {
                switch (MassivePoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 15)
                            MassiveButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 20)
                            MassiveButton.IsEnabled = true;
                        else
                            MassiveButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 25)
                            MassiveButton.IsEnabled = true;
                        else
                            MassiveButton.IsEnabled = false;
                        break;
                    case 3:
                        if (DefenderSkillPoints >= 30)
                            MassiveButton.IsEnabled = true;
                        else
                            MassiveButton.IsEnabled = false;
                        break;
                    case 4:
                        if (DefenderSkillPoints >= 35)
                            MassiveButton.IsEnabled = true;
                        else
                            MassiveButton.IsEnabled = false;
                        break;
                    case 5:
                        MassiveButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (BastionPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 15)
                        BastionButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 20)
                        BastionButton.IsEnabled = true;
                    else
                        BastionButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 25)
                        BastionButton.IsEnabled = true;
                    else
                        BastionButton.IsEnabled = false;
                    break;
                case 3:
                    BastionButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (DefenderSkillPoints >= 15)
            {
                StoneButton.IsEnabled = true;
                if (StonePoints == 3)
                    StoneButton.IsEnabled = false;
            }

            if (RapidPoints >= 1)
            {
                switch (ShieldPoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 20)
                            ShieldButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 25)
                            ShieldButton.IsEnabled = true;
                        else
                            ShieldButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 30)
                            ShieldButton.IsEnabled = true;
                        else
                            ShieldButton.IsEnabled = false;
                        break;
                    case 3:
                        ShieldButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (SteelPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 20)
                        SteelButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 25)
                        SteelButton.IsEnabled = true;
                    else
                        SteelButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 30)
                        SteelButton.IsEnabled = true;
                    else
                        SteelButton.IsEnabled = false;
                    break;
                case 3:
                    SteelButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (FortifyPoints >= 1)
            {
                switch (EshoutPoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 20)
                            EshoutButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 25)
                            EshoutButton.IsEnabled = true;
                        else
                            EshoutButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 30)
                            EshoutButton.IsEnabled = true;
                        else
                            EshoutButton.IsEnabled = false;
                        break;
                    case 3:
                        EshoutButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (DefenderSkillPoints >= 25)
            {
                ResilianceButton.IsEnabled = true;
                if (ResiliancePoints == 2)
                    ResilianceButton.IsEnabled = false;
            }

            if (ChaoticPoints >= 1)
            {
                switch (GalePoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 25)
                            GaleButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 30)
                            GaleButton.IsEnabled = true;
                        else
                            GaleButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 35)
                            GaleButton.IsEnabled = true;
                        else
                            GaleButton.IsEnabled = false;
                        break;
                    case 3:
                        GaleButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (DefenderSkillPoints >= 25)
            {
                EvastrikeButton.IsEnabled = true;
                if (EvastrikePoints == 1)
                {
                    EvastrikeButton.IsEnabled = false;
                }
            }

            switch (VigilancePoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 25)
                        VigilanceButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 30)
                        VigilanceButton.IsEnabled = true;
                    else
                        VigilanceButton.IsEnabled = false;
                    break;
                case 2:
                    VigilanceButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (EshoutPoints >= 1)
            {
                switch (DshoutPoints)
                {
                    case 0:
                        if (DefenderSkillPoints >= 15)
                            DshoutButton.IsEnabled = true;
                        break;
                    case 1:
                        if (DefenderSkillPoints >= 20)
                            DshoutButton.IsEnabled = true;
                        else
                            DshoutButton.IsEnabled = false;
                        break;
                    case 2:
                        if (DefenderSkillPoints >= 25)
                            DshoutButton.IsEnabled = true;
                        else
                            DshoutButton.IsEnabled = false;
                        break;
                    case 3:
                        DshoutButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (ThreatenPoints)
            {
                case 0:
                    if (DefenderSkillPoints >= 30)
                        ThreatenButton.IsEnabled = true;
                    break;
                case 1:
                    if (DefenderSkillPoints >= 35)
                        ThreatenButton.IsEnabled = true;
                    else
                        ThreatenButton.IsEnabled = false;
                    break;
                case 2:
                    if (DefenderSkillPoints >= 40)
                        ThreatenButton.IsEnabled = true;
                    else
                        ThreatenButton.IsEnabled = false;
                    break;
                case 3:
                    ThreatenButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (DefenderSkillPoints >= 30)
            {
                RetributionButton.IsEnabled = true;
                if (RetributionPoints == 3)
                    RetributionButton.IsEnabled = false;
            }
        }

        public void UpdateSorcererTree()
        {
            switch (FireArrowPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 0)
                        FireArrowButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 5)
                        FireArrowButton.IsEnabled = true;
                    else
                        FireArrowButton.IsEnabled = false;
                    break;
                case 2:
                    if (SorcererSkillPoints >= 10)
                        FireArrowButton.IsEnabled = true;
                    else
                        FireArrowButton.IsEnabled = false;
                    break;
                case 3:
                    FireArrowButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (RapidBlastPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 0)
                        RapidBlastButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 5)
                        RapidBlastButton.IsEnabled = true;
                    else
                        RapidBlastButton.IsEnabled = false;
                    break;
                case 2:
                    if (SorcererSkillPoints >= 10)
                        RapidBlastButton.IsEnabled = true;
                    else
                        RapidBlastButton.IsEnabled = false;
                    break;
                case 3:
                    RapidBlastButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (IceThornsPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 0)
                        IceThornsButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 5)
                        IceThornsButton.IsEnabled = true;
                    else
                        IceThornsButton.IsEnabled = false;
                    break;
                case 2:
                    if (SorcererSkillPoints >= 10)
                        IceThornsButton.IsEnabled = true;
                    else
                        IceThornsButton.IsEnabled = false;
                    break;
                case 3:
                    if (SorcererSkillPoints >= 15)
                        IceThornsButton.IsEnabled = true;
                    else
                        IceThornsButton.IsEnabled = false;
                    break;
                case 4:
                    if (SorcererSkillPoints >= 20)
                        IceThornsButton.IsEnabled = true;
                    else
                        IceThornsButton.IsEnabled = false;
                    break;
                case 5:
                    IceThornsButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            switch (IceArrowPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 0)
                        IceArrowButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 5)
                        IceArrowButton.IsEnabled = true;
                    else
                        IceArrowButton.IsEnabled = false;
                    break;
                case 2:
                    IceArrowButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (SorcererSkillPoints >= 0)
            {
                AnalyticsButton.IsEnabled = true;
                if (AnalyticsPoints == 3)
                    AnalyticsButton.IsEnabled = false;
            }

            if (SorcererSkillPoints >= 0)
            {
                MagicMasteryButton.IsEnabled = true;
                if (MagicMasteryPoints == 5)
                    MagicMasteryButton.IsEnabled = false;
            }

            if (RapidBlastPoints >= 1)
            {
                switch (ImpactPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 5)
                            ImpactButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 10)
                            ImpactButton.IsEnabled = true;
                        else
                            ImpactButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 15)
                            ImpactButton.IsEnabled = true;
                        else
                            ImpactButton.IsEnabled = false;
                        break;
                    case 3:
                        if (SorcererSkillPoints >= 20)
                            ImpactButton.IsEnabled = true;
                        else
                            ImpactButton.IsEnabled = false;
                        break;
                    case 4:
                        if (SorcererSkillPoints >= 25)
                            ImpactButton.IsEnabled = true;
                        else
                            ImpactButton.IsEnabled = false;
                        break;
                    case 5:
                        ImpactButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (MeditationPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 5)
                        MeditationButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 10)
                        MeditationButton.IsEnabled = true;
                    else
                        MeditationButton.IsEnabled = false;
                    break;
                case 2:
                    MeditationButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (FireArrowPoints >= 1)
            {
                switch (FireOrbPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 10)
                            FireOrbButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 15)
                            FireOrbButton.IsEnabled = true;
                        else
                            FireOrbButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 20)
                            FireOrbButton.IsEnabled = true;
                        else
                            FireOrbButton.IsEnabled = false;
                        break;
                    case 3:
                        FireOrbButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (IceThornsPoints >= 1)
            {
                switch (IceBarrierPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 10)
                            IceBarrierButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 15)
                            IceBarrierButton.IsEnabled = true;
                        else
                            IceBarrierButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 20)
                            IceBarrierButton.IsEnabled = true;
                        else
                            IceBarrierButton.IsEnabled = false;
                        break;
                    case 3:
                        if (SorcererSkillPoints >= 25)
                            IceBarrierButton.IsEnabled = true;
                        else
                            IceBarrierButton.IsEnabled = false;
                        break;
                    case 4:
                        if (SorcererSkillPoints >= 30)
                            IceBarrierButton.IsEnabled = true;
                        else
                            IceBarrierButton.IsEnabled = false;
                        break;
                    case 5:
                        IceBarrierButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (IceArrowPoints >= 1)
            {
                switch (IceOrbPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 10)
                            IceOrbButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 15)
                            IceOrbButton.IsEnabled = true;
                        else
                            IceOrbButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 20)
                            IceOrbButton.IsEnabled = true;
                        else
                            IceOrbButton.IsEnabled = false;
                        break;
                    case 3:
                        IceOrbButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (SorcererSkillPoints >= 10)
            {
                IntricacyButton.IsEnabled = true;
                if (IntricacyPoints == 2)
                    IntricacyButton.IsEnabled = false;
            }

            if (ImpactPoints >= 1)
            {
                switch (FirePillarPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 15)
                            FirePillarButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 20)
                            FirePillarButton.IsEnabled = true;
                        else
                            FirePillarButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 25)
                            FirePillarButton.IsEnabled = true;
                        else
                            FirePillarButton.IsEnabled = false;
                        break;
                    case 3:
                        if (SorcererSkillPoints >= 30)
                            FirePillarButton.IsEnabled = true;
                        else
                            FirePillarButton.IsEnabled = false;
                        break;
                    case 4:
                        if (SorcererSkillPoints >= 35)
                            FirePillarButton.IsEnabled = true;
                        else
                            FirePillarButton.IsEnabled = false;
                        break;
                    case 5:
                        FirePillarButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (ColdArmorPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 15)
                        ColdArmorButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 20)
                        ColdArmorButton.IsEnabled = true;
                    else
                        ColdArmorButton.IsEnabled = false;
                    break;
                case 2:
                    if (SorcererSkillPoints >= 25)
                        ColdArmorButton.IsEnabled = true;
                    else
                        ColdArmorButton.IsEnabled = false;
                    break;
                case 3:
                    ColdArmorButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (MeditationPoints >= 1)
            {
                switch (EpcrystalPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 15)
                            EpcrystalButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 20)
                            EpcrystalButton.IsEnabled = true;
                        else
                            EpcrystalButton.IsEnabled = false;
                        break;
                    case 2:
                        EpcrystalButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (SorcererSkillPoints >= 15)
            {
                FlameConcentrationButton.IsEnabled = true;
                if (FlameConcentrationPoints == 2)
                    FlameConcentrationButton.IsEnabled = false;
            }

            if (FireOrbPoints >= 1)
            {
                switch (MeteorPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 20)
                            MeteorButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 25)
                            MeteorButton.IsEnabled = true;
                        else
                            MeteorButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 30)
                            MeteorButton.IsEnabled = true;
                        else
                            MeteorButton.IsEnabled = false;
                        break;
                    case 3:
                        if (SorcererSkillPoints >= 35)
                            MeteorButton.IsEnabled = true;
                        else
                            MeteorButton.IsEnabled = false;
                        break;
                    case 4:
                        if (SorcererSkillPoints >= 40)
                            MeteorButton.IsEnabled = true;
                        else
                            MeteorButton.IsEnabled = false;
                        break;
                    case 5:
                        MeteorButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            switch (FireArmorPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 20)
                        FireArmorButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 25)
                        FireArmorButton.IsEnabled = true;
                    else
                        FireArmorButton.IsEnabled = false;
                    break;
                case 2:
                    if (SorcererSkillPoints >= 30)
                        FireArmorButton.IsEnabled = true;
                    else
                        FireArmorButton.IsEnabled = false;
                    break;
                case 3:
                    FireArmorButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (IceOrbPoints >= 1)
            {
                switch (ColdWavePoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 20)
                            ColdWaveButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 25)
                            ColdWaveButton.IsEnabled = true;
                        else
                            ColdWaveButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 30)
                            ColdWaveButton.IsEnabled = true;
                        else
                            ColdWaveButton.IsEnabled = false;
                        break;
                    case 3:
                        if (SorcererSkillPoints >= 35)
                            ColdWaveButton.IsEnabled = true;
                        else
                            ColdWaveButton.IsEnabled = false;
                        break;
                    case 4:
                        if (SorcererSkillPoints >= 40)
                            ColdWaveButton.IsEnabled = true;
                        else
                            ColdWaveButton.IsEnabled = false;
                        break;
                    case 5:
                        ColdWaveButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }

            if (SorcererSkillPoints >= 20)
            {
                HarmonyButton.IsEnabled = true;
                if (HarmonyPoints == 2)
                    HarmonyButton.IsEnabled = false;
            }

            if (SorcererSkillPoints >= 25)
            {
                CrystalButton.IsEnabled = true;
                if (CrystalPoints == 1)
                    CrystalButton.IsEnabled = false;
            }

            switch (WisdomPoints)
            {
                case 0:
                    if (SorcererSkillPoints >= 25)
                        WisdomButton.IsEnabled = true;
                    break;
                case 1:
                    if (SorcererSkillPoints >= 30)
                        WisdomButton.IsEnabled = true;
                    else
                        WisdomButton.IsEnabled = false;
                    break;
                case 2:
                    if (SorcererSkillPoints >= 35)
                        WisdomButton.IsEnabled = true;
                    else
                        WisdomButton.IsEnabled = false;
                    break;
                case 3:
                    WisdomButton.IsEnabled = false;
                    break;
                default:
                    break;
            }

            if (FireArmorPoints >= 1)
            {
                switch (FlameTornadoPoints)
                {
                    case 0:
                        if (SorcererSkillPoints >= 30)
                            FlameTornadoButton.IsEnabled = true;
                        break;
                    case 1:
                        if (SorcererSkillPoints >= 35)
                            FlameTornadoButton.IsEnabled = true;
                        else
                            FlameTornadoButton.IsEnabled = false;
                        break;
                    case 2:
                        if (SorcererSkillPoints >= 40)
                            FlameTornadoButton.IsEnabled = true;
                        else
                            FlameTornadoButton.IsEnabled = false;
                        break;
                    case 3:
                        FlameTornadoButton.IsEnabled = false;
                        break;
                    default:
                        break;
                }

            }

            if (SorcererSkillPoints >= 30)
            {
                ImbalanceButton.IsEnabled = true;
                if (ImbalancePoints == 2)
                    ImbalanceButton.IsEnabled = false;
            }
        }
        // END
        // Local methods

        // Disabling Mastery
        // START
        public void DisableAssassinMastery()
        {
            PursuitLvl1.IsEnabled = false;
            PushbackLvl1.IsEnabled = false;
            CrossClassLvl1.IsEnabled = false; ;
            RazorLvl1.IsEnabled = false;
            ConcentrationLvl1.IsEnabled = false;
            RazorLvl2.IsEnabled = false;
            ConcentrationLvl2.IsEnabled = false;
            RazorLvl3.IsEnabled = false;
        }

        public void DisableBerserkerMastery()
        {
            OutrageLvl1.IsEnabled = false;
            ChainMasteryLvl1.IsEnabled = false;
            StyleMasteryLvl1.IsEnabled = false;
            PlateMasteryLvl1.IsEnabled = false;
            ThirstLvl1.IsEnabled = false;
            SustainedLvl1.IsEnabled = false;
            ThirstLvl2.IsEnabled = false;
            SustainedLvl2.IsEnabled = false;
            ThirstLvl3.IsEnabled = false;
        }

        public void DisableClericMastery()
        {
            PossessLvl1.IsEnabled = false;
            HealLvl1.IsEnabled = false;
            StyleMasteryClericLvl1.IsEnabled = false;
            ChainMasteryClericLvl1.IsEnabled = false;
            HealLvl2.IsEnabled = false;
            HolyStrikingLvl1.IsEnabled = false;
            ResurrectLvl1.IsEnabled = false;
            HealLvl3.IsEnabled = false;
            HolyStrikingLvl2.IsEnabled = false;
            ResurrectLvl2.IsEnabled = false;
        }

        public void DisableDefenderMastery()
        {
            CounterattackLvl1.IsEnabled = false;
            ChainMasteryDefLvl1.IsEnabled = false;
            StyleMasteryDefLvl1.IsEnabled = false;
            PlateMasteryDefLvl1.IsEnabled = false;
            PhyTrainingLvl1.IsEnabled = false;
            ExtendCounterLvl1.IsEnabled = false;
            PhyTrainingLvl2.IsEnabled = false;
            ExtendCounterLvl2.IsEnabled = false;
            PhyTrainingLvl3.IsEnabled = false;
        }

        public void DisableSorcererMastery()
        {
            AwakeningLvl1.IsEnabled = false;
            StyleMasterySorcLvl1.IsEnabled = false;
            AffinityLvl1.IsEnabled = false;
            DynamicsLvl1.IsEnabled = false;
            AffinityLvl2.IsEnabled = false;
            DynamicsLvl2.IsEnabled = false;
            AffinityLvl3.IsEnabled = false;
        }
        // END
        // Disabling Mastery

        // NotifyPropertyChanged method to notify DataBinding about property update
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        // Commands
        // START
        private void ResetAllTrees_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ResetAllTrees_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ResetAllSkillTrees();
        }

        private void ChaosButton_Click(object sender, RoutedEventArgs e)
        {
            ChaosPoints += 1;
            ChaosButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void CleaveButton_Click(object sender, RoutedEventArgs e)
        {
            CleavePoints += 1;
            CleaveButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void CycloneButton_Click(object sender, RoutedEventArgs e)
        {
            CyclonePoints += 1;
            CycloneButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void EnduranceButton_Click(object sender, RoutedEventArgs e)
        {
            EndurancePoints += 1;
            EnduranceButton.IsEnabled = false;
            IncrementAssassinPoint();
            UpdateDamageReductions();
        }

        private void DaggerMasteryButton_Click(object sender, RoutedEventArgs e)
        {
            DaggerMasteryPoints += 1;
            DaggerMasteryButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void LeapButton_Click(object sender, RoutedEventArgs e)
        {
            LeapPoints += 1;
            LeapButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void StabButton_Click(object sender, RoutedEventArgs e)
        {
            StabPoints += 1;
            StabButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void ResButton_Click(object sender, RoutedEventArgs e)
        {
            ResPoints += 1;
            ResButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void StormButton_Click(object sender, RoutedEventArgs e)
        {
            StormPoints += 1;
            StormButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void PeneButton_Click(object sender, RoutedEventArgs e)
        {
            PenePoints += 1;
            PeneButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void BlinkButton_Click(object sender, RoutedEventArgs e)
        {
            BlinkPoints += 1;
            BlinkButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void AcrobaticsButton_Click(object sender, RoutedEventArgs e)
        {
            AcrobaticsPoints += 1;
            AcrobaticsButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void BicycleButton_Click(object sender, RoutedEventArgs e)
        {
            BicyclePoints += 1;
            BicycleButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void VeilButton_Click(object sender, RoutedEventArgs e)
        {
            VeilPoints += 1;
            VeilButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void AdrenButton_Click(object sender, RoutedEventArgs e)
        {
            AdrenPoints += 1;
            AdrenButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void DragonButton_Click(object sender, RoutedEventArgs e)
        {
            DragonPoints += 1;
            DragonButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void WhirlButton_Click(object sender, RoutedEventArgs e)
        {
            WhirlPoints += 1;
            WhirlButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void SeizeButton_Click(object sender, RoutedEventArgs e)
        {
            SeizePoints += 1;
            SeizeButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void ShadowStrikeButton_Click(object sender, RoutedEventArgs e)
        {
            ShadowStrikePoints += 1;
            ShadowStrikeButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void ShadowDanceButton_Click(object sender, RoutedEventArgs e)
        {
            ShadowDancePoints += 1;
            ShadowDanceButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void FortButton_Click(object sender, RoutedEventArgs e)
        {
            FortPoints += 1;
            FortButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void BladeDanceButton_Click(object sender, RoutedEventArgs e)
        {
            BladeDancePoints += 1;
            BladeDanceButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void InvigButton_Click(object sender, RoutedEventArgs e)
        {
            InvigPoints += 1;
            InvigButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        private void ColdBloodedButton_Click(object sender, RoutedEventArgs e)
        {
            ColdBloodedPoints += 1;
            ColdBloodedButton.IsEnabled = false;
            IncrementAssassinPoint();
        }

        public void IncrementAssassinPoint()
        {
            AssassinSkillPoints += 1;
            AllocatedSkillPoints += 1;
            RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
            UpdateSkillsAvailability();
        }

        private void CrushButton_Click(object sender, RoutedEventArgs e)
        {
            CrushPoints += 1;
            CrueltyButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void NeutralizeButton_Click(object sender, RoutedEventArgs e)
        {
            NeutralizePoints += 1;
            NeutralizeButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void DodgeButton_Click(object sender, RoutedEventArgs e)
        {
            DodgePoints += 1;
            DodgeButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void NoMercyButton_Click(object sender, RoutedEventArgs e)
        {
            NoMercyPoints += 1;
            NoMercyButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void TwoHandedButton_Click(object sender, RoutedEventArgs e)
        {
            TwoHandedPoints += 1;
            TwoHandedButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void NocturneButton_Click(object sender, RoutedEventArgs e)
        {
            NocturnePoints += 1;
            NocturneButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void BerserkButton_Click(object sender, RoutedEventArgs e)
        {
            BerserkPoints += 1;
            BerserkButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void BuffaloButton_Click(object sender, RoutedEventArgs e)
        {
            BuffaloPoints += 1;
            BuffaloButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void FuriousButton_Click(object sender, RoutedEventArgs e)
        {
            FuriousPoints += 1;
            FuriousButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void FeastButton_Click(object sender, RoutedEventArgs e)
        {
            FeastPoints += 1;
            FeastButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void VanquishButton_Click(object sender, RoutedEventArgs e)
        {
            VanquishPoints += 1;
            VanquishButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void ArmageddonButton_Click(object sender, RoutedEventArgs e)
        {
            ArmageddonPoints += 1;
            ArmageddonButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void InertiaButton_Click(object sender, RoutedEventArgs e)
        {
            InertiaPoints += 1;
            InertiaButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void TranquilityButton_Click(object sender, RoutedEventArgs e)
        {
            TranquilityPoints += 1;
            TranquilityButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void CrueltyButton_Click(object sender, RoutedEventArgs e)
        {
            CrueltyPoints += 1;
            CrueltyButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void BashButton_Click(object sender, RoutedEventArgs e)
        {
            BashPoints += 1;
            BashButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void ScamperButton_Click(object sender, RoutedEventArgs e)
        {
            ScamperPoints += 1;
            ScamperButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void WoundsButton_Click(object sender, RoutedEventArgs e)
        {
            WoundsPoints += 1;
            WoundsButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void UpwardButton_Click(object sender, RoutedEventArgs e)
        {
            UpwardPoints += 1;
            UpwardButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            EscapePoints += 1;
            EscapeButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void TornadoButton_Click(object sender, RoutedEventArgs e)
        {
            TornadoPoints += 1;
            TornadoButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void MadnessButton_Click(object sender, RoutedEventArgs e)
        {
            MadnessPoints += 1;
            MadnessButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        private void ZerkBloodButton_Click(object sender, RoutedEventArgs e)
        {
            ZerkBloodPoints += 1;
            ZerkBloodButton.IsEnabled = false;
            IncrementBerserkerPoint();
        }

        public void IncrementBerserkerPoint()
        {
            BerserkerSkillPoints += 1;
            AllocatedSkillPoints += 1;
            RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
            UpdateSkillsAvailability();
        }

        private void LightButton_Click(object sender, RoutedEventArgs e)
        {
            LightPoints += 1;
            LightButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void DivineButton_Click(object sender, RoutedEventArgs e)
        {
            DivinePoints += 1;
            DivineButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void RevitalizeButton_Click(object sender, RoutedEventArgs e)
        {
            RevitalizePoints += 1;
            RevitalizeButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void RepercussionButton_Click(object sender, RoutedEventArgs e)
        {
            RepercussionPoints += 1;
            RepercussionButton.IsEnabled = false;
            IncrementClericPoint();
            UpdateDamageReductions();
        }

        private void DivineMasteryButton_Click(object sender, RoutedEventArgs e)
        {
            DivineMasteryPoints += 1;
            DivineMasteryButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void FocusedButton_Click(object sender, RoutedEventArgs e)
        {
            FocusedPoints += 1;
            FocusedButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void EnduranceBlessingButton_Click(object sender, RoutedEventArgs e)
        {
            EnduranceBlessingPoints += 1;
            EnduranceBlessingButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void PleasureButton_Click(object sender, RoutedEventArgs e)
        {
            PleasurePoints += 1;
            PleasureButton.IsEnabled = false;
            IncrementClericPoint();
            UpdateDamageReductions();
        }

        private void JudgeButton_Click(object sender, RoutedEventArgs e)
        {
            JudgePoints += 1;
            JudgeButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void CopButton_Click(object sender, RoutedEventArgs e)
        {
            CopPoints += 1;
            CopButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void CohButton_Click(object sender, RoutedEventArgs e)
        {
            CohPoints += 1;
            CopButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void MindTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            MindTrainingPoints += 1;
            MindTrainingButton.IsEnabled = false;
            IncrementClericPoint();
            UpdateDamageReductions();
        }

        private void HealingButton_Click(object sender, RoutedEventArgs e)
        {
            HealingPoints += 1;
            HealingButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void DireButton_Click(object sender, RoutedEventArgs e)
        {
            DirePoints += 1;
            DireButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void ConcentrationButton_Click(object sender, RoutedEventArgs e)
        {
            ConcentrationPoints += 1;
            ConcentrationButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void ArbitrationButton_Click(object sender, RoutedEventArgs e)
        {
            ArbitrationPoints += 1;
            ArbitrationButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void LinksButton_Click(object sender, RoutedEventArgs e)
        {
            LinksPoints += 1;
            LinksButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void RecoveryButton_Click(object sender, RoutedEventArgs e)
        {
            RecoveryPoints += 1;
            RecoveryButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void OrbsButton_Click(object sender, RoutedEventArgs e)
        {
            OrbsPoints += 1;
            OrbsButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void GoddessButton_Click(object sender, RoutedEventArgs e)
        {
            GoddessPoints += 1;
            GoddessButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void UpliftButton_Click(object sender, RoutedEventArgs e)
        {
            UpliftPoints += 1;
            UpliftButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void WhirlpoolButton_Click(object sender, RoutedEventArgs e)
        {
            WhirlpoolPoints += 1;
            WhirlpoolButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void SalvationButton_Click(object sender, RoutedEventArgs e)
        {
            SalvationPoints += 1;
            SalvationButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void SwiftnessButton_Click(object sender, RoutedEventArgs e)
        {
            SwiftnessPoints += 1;
            SwiftnessButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void PriestButton_Click(object sender, RoutedEventArgs e)
        {
            PriestPoints += 1;
            PriestButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void StormJudgementButton_Click(object sender, RoutedEventArgs e)
        {
            StormJudgementPoints += 1;
            StormJudgementButton.IsEnabled = false;
            IncrementClericPoint();
        }

        private void NimbleButton_Click(object sender, RoutedEventArgs e)
        {
            NimblePoints += 1;
            NimbleButton.IsEnabled = false;
            IncrementClericPoint();
        }

        public void IncrementClericPoint()
        {
            ClericSkillPoints += 1;
            AllocatedSkillPoints += 1;
            RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
            UpdateSkillsAvailability();
        }

        private void RuinButton_Click(object sender, RoutedEventArgs e)
        {
            RuinPoints += 1;
            RuinButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void StunningButton_Click(object sender, RoutedEventArgs e)
        {
            StunningPoints += 1;
            StunningButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void RushButton_Click(object sender, RoutedEventArgs e)
        {
            RushPoints += 1;
            RushButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void ThornButton_Click(object sender, RoutedEventArgs e)
        {
            ThornPoints += 1;
            ThornButton.IsEnabled = false;
            IncrementDefenderPoint();
            UpdateDamageReductions();
        }

        private void OneHandedButton_Click(object sender, RoutedEventArgs e)
        {
            OneHandedPoints += 1;
            OneHandedButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void SlamButton_Click(object sender, RoutedEventArgs e)
        {
            SlamPoints += 1;
            SlamButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void ComebackButton_Click(object sender, RoutedEventArgs e)
        {
            ComebackPoints += 1;
            ComebackButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void PiercingButton_Click(object sender, RoutedEventArgs e)
        {
            PiercingPoints += 1;
            PiercingButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void RapidButton_Click(object sender, RoutedEventArgs e)
        {
            RapidPoints += 1;
            RapidButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void FortifyButton_Click(object sender, RoutedEventArgs e)
        {
            FortifyPoints += 1;
            FortifyButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void DefenseMasteryButton_Click(object sender, RoutedEventArgs e)
        {
            DefenseMasteryPoints += 1;
            DefenseMasteryButton.IsEnabled = false;
            IncrementDefenderPoint();
            UpdateDamageReductions();
        }

        private void ChaoticButton_Click(object sender, RoutedEventArgs e)
        {
            ChaoticPoints += 1;
            ChaoticButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void MassiveButton_Click(object sender, RoutedEventArgs e)
        {
            MassivePoints += 1;
            MassiveButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void BastionButton_Click(object sender, RoutedEventArgs e)
        {
            BastionPoints += 1;
            BastionButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void StoneButton_Click(object sender, RoutedEventArgs e)
        {
            StonePoints += 1;
            StoneButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void ShieldButton_Click(object sender, RoutedEventArgs e)
        {
            ShieldPoints += 1;
            ShieldButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void SteelButton_Click(object sender, RoutedEventArgs e)
        {
            SteelPoints += 1;
            SteelButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void EshoutButton_Click(object sender, RoutedEventArgs e)
        {
            EshoutPoints += 1;
            EshoutButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void ResilianceButton_Click(object sender, RoutedEventArgs e)
        {
            ResiliancePoints += 1;
            ResilianceButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void GaleButton_Click(object sender, RoutedEventArgs e)
        {
            GalePoints += 1;
            GaleButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void EvastrikeButton_Click(object sender, RoutedEventArgs e)
        {
            EvastrikePoints += 1;
            EvastrikeButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void VigilanceButton_Click(object sender, RoutedEventArgs e)
        {
            VigilancePoints += 1;
            VigilanceButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void DshoutButton_Click(object sender, RoutedEventArgs e)
        {
            DshoutPoints += 1;
            DshoutButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void ThreatenButton_Click(object sender, RoutedEventArgs e)
        {
            ThreatenPoints += 1;
            ThreatenButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        private void RetributionButton_Click(object sender, RoutedEventArgs e)
        {
            RetributionPoints += 1;
            RetributionButton.IsEnabled = false;
            IncrementDefenderPoint();
        }

        public void IncrementDefenderPoint()
        {
            DefenderSkillPoints += 1;
            AllocatedSkillPoints += 1;
            RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
            UpdateSkillsAvailability();
            UpdateDamageReductions();
        }

        private void FireArrowButton_Click(object sender, RoutedEventArgs e)
        {
            FireArrowPoints += 1;
            FireArrowButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void RapidBlastButton_Click(object sender, RoutedEventArgs e)
        {
            RapidBlastPoints += 1;
            RapidBlastButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void IceThornsButton_Click(object sender, RoutedEventArgs e)
        {
            IceThornsPoints += 1;
            IceThornsButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void IceArrowButton_Click(object sender, RoutedEventArgs e)
        {
            IceArrowPoints += 1;
            IceArrowButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void AnalyticsButton_Click(object sender, RoutedEventArgs e)
        {
            AnalyticsPoints += 1;
            AnalyticsButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void MagicMasteryButton_Click(object sender, RoutedEventArgs e)
        {
            MagicMasteryPoints += 1;
            MagicMasteryButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void ImpactButton_Click(object sender, RoutedEventArgs e)
        {
            ImpactPoints += 1;
            ImpactButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void MeditationButton_Click(object sender, RoutedEventArgs e)
        {
            MeditationPoints += 1;
            MeditationButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void FireOrbButton_Click(object sender, RoutedEventArgs e)
        {
            FireOrbPoints += 1;
            FireOrbButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void IceBarrierButton_Click(object sender, RoutedEventArgs e)
        {
            IceBarrierPoints += 1;
            IceBarrierButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void IceOrbButton_Click(object sender, RoutedEventArgs e)
        {
            IceOrbPoints += 1;
            IceOrbButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void IntricacyButton_Click(object sender, RoutedEventArgs e)
        {
            IntricacyPoints += 1;
            IntricacyButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void FirePillarButton_Click(object sender, RoutedEventArgs e)
        {
            FirePillarPoints += 1;
            FirePillarButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void ColdArmorButton_Click(object sender, RoutedEventArgs e)
        {
            ColdArmorPoints += 1;
            ColdArmorButton.IsEnabled = false;
            IncrementSorcererPoint();
            UpdateDamageReductions();
        }

        private void EpcrystalButton_Click(object sender, RoutedEventArgs e)
        {
            EpcrystalPoints += 1;
            EpcrystalButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void FlameConcentrationButton_Click(object sender, RoutedEventArgs e)
        {
            FlameConcentrationPoints += 1;
            FlameConcentrationButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void MeteorButton_Click(object sender, RoutedEventArgs e)
        {
            MeteorPoints += 1;
            MeteorButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void FireArmorButton_Click(object sender, RoutedEventArgs e)
        {
            FireArmorPoints += 1;
            FireArmorButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void ColdWaveButton_Click(object sender, RoutedEventArgs e)
        {
            ColdWavePoints += 1;
            ColdWaveButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void HarmonyButton_Click(object sender, RoutedEventArgs e)
        {
            HarmonyPoints += 1;
            HarmonyButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void CrystalButton_Click(object sender, RoutedEventArgs e)
        {
            CrystalPoints += 1;
            CrystalButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void WisdomButton_Click(object sender, RoutedEventArgs e)
        {
            WisdomPoints += 1;
            WisdomButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void FlameTornadoButton_Click(object sender, RoutedEventArgs e)
        {
            FlameTornadoPoints += 1;
            FlameTornadoButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        private void ImbalanceButton_Click(object sender, RoutedEventArgs e)
        {
            ImbalancePoints += 1;
            ImbalanceButton.IsEnabled = false;
            IncrementSorcererPoint();
        }

        public void IncrementSorcererPoint()
        {
            SorcererSkillPoints += 1;
            AllocatedSkillPoints += 1;
            RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
            UpdateSkillsAvailability();
        }

        private void ResetAssassinTree_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((AssassinSkillPoints > 0) && (AssassinSkillPoints == AllocatedSkillPoints))
                e.CanExecute = true;
            else if ((AssassinSkillPoints > 0) && (AssassinSkillPoints > AllocatedSkillPoints))
                throw new Exception();
            else if ((AssassinSkillPoints > 0) && (AssassinSkillPoints < AllocatedSkillPoints))
            {
                if (BaseSkillTree != "Assassin")
                    e.CanExecute = true;
                else
                {
                    e.CanExecute = false;
                    if ((BerserkerSkillPoints >= 10) || (ClericSkillPoints >= 10) || (DefenderSkillPoints >= 10) || (SorcererSkillPoints >= 10))
                        e.CanExecute = true;
                }
            }
            else
                e.CanExecute = false;
        }

        private void ResetAssassinTree_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (AssassinSkillPoints == AllocatedSkillPoints)
                ResetAllSkillTrees();
            else
            {
                AllocatedSkillPoints -= AssassinSkillPoints;
                RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
                AssassinSkillPoints = 0;
                ResetAssassinTabPoints();
                DisableAssassinTreeButtons();
                UpdateSkillsAvailability();
                UpdateDamageReductions();
            }
        }

        private void ResetBerserkerTree_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((BerserkerSkillPoints > 0) && (BerserkerSkillPoints == AllocatedSkillPoints))
                e.CanExecute = true;
            else if ((BerserkerSkillPoints > 0) && (BerserkerSkillPoints > AllocatedSkillPoints))
                throw new Exception();
            else if ((BerserkerSkillPoints > 0) && (BerserkerSkillPoints < AllocatedSkillPoints))
            {
                if (BaseSkillTree != "Berserker")
                    e.CanExecute = true;
                else
                {
                    e.CanExecute = false;
                    if ((AssassinSkillPoints >= 10) || (ClericSkillPoints >= 10) || (DefenderSkillPoints >= 10) || (SorcererSkillPoints >= 10))
                        e.CanExecute = true;
                }
            }
            else
                e.CanExecute = false;
        }

        private void ResetBerserkerTree_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (BerserkerSkillPoints == AllocatedSkillPoints)
                ResetAllSkillTrees();
            else
            {
                AllocatedSkillPoints -= BerserkerSkillPoints;
                RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
                BerserkerSkillPoints = 0;
                ResetBerserkerTabPoints();
                DisableBerserkerTreeButtons();
                UpdateSkillsAvailability();
                UpdateDamageReductions();
            }
        }

        private void ResetClericTree_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((ClericSkillPoints > 0) && (ClericSkillPoints == AllocatedSkillPoints))
                e.CanExecute = true;
            else if ((ClericSkillPoints > 0) && (ClericSkillPoints > AllocatedSkillPoints))
                throw new Exception();
            else if ((ClericSkillPoints > 0) && (ClericSkillPoints < AllocatedSkillPoints))
            {
                if (BaseSkillTree != "Cleric")
                    e.CanExecute = true;
                else
                {
                    e.CanExecute = false;
                    if ((BerserkerSkillPoints >= 10) || (AssassinSkillPoints >= 10) || (DefenderSkillPoints >= 10) || (SorcererSkillPoints >= 10))
                        e.CanExecute = true;
                }
            }
            else
                e.CanExecute = false;
        }

        private void ResetClericTree_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ClericSkillPoints == AllocatedSkillPoints)
                ResetAllSkillTrees();
            else
            {
                AllocatedSkillPoints -= ClericSkillPoints;
                RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
                ClericSkillPoints = 0;
                ResetClericTabPoints();
                DisableClericTreeButtons();
                UpdateSkillsAvailability();
                UpdateDamageReductions();
            }
        }

        private void ResetDefenderTree_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((DefenderSkillPoints > 0) && (DefenderSkillPoints == AllocatedSkillPoints))
                e.CanExecute = true;
            else if ((DefenderSkillPoints > 0) && (DefenderSkillPoints > AllocatedSkillPoints))
                throw new Exception();
            else if ((DefenderSkillPoints > 0) && (DefenderSkillPoints < AllocatedSkillPoints))
            {
                if (BaseSkillTree != "Defender")
                    e.CanExecute = true;
                else
                {
                    e.CanExecute = false;
                    if ((BerserkerSkillPoints >= 10) || (ClericSkillPoints >= 10) || (AssassinSkillPoints >= 10) || (SorcererSkillPoints >= 10))
                        e.CanExecute = true;
                }
            }
            else
                e.CanExecute = false;
        }

        private void ResetDefenderTree_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (DefenderSkillPoints == AllocatedSkillPoints)
                ResetAllSkillTrees();
            else
            {
                AllocatedSkillPoints -= DefenderSkillPoints;
                RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
                DefenderSkillPoints = 0;
                ResetDefenderTabPoints();
                DisableDefenderTreeButtons();
                UpdateSkillsAvailability();
                UpdateDamageReductions();
            }
        }

        private void ResetSorcererTree_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((SorcererSkillPoints > 0) && (SorcererSkillPoints == AllocatedSkillPoints))
                e.CanExecute = true;
            else if ((SorcererSkillPoints > 0) && (SorcererSkillPoints > AllocatedSkillPoints))
                throw new Exception();
            else if ((SorcererSkillPoints > 0) && (SorcererSkillPoints < AllocatedSkillPoints))
            {
                if (BaseSkillTree != "Sorcerer")
                    e.CanExecute = true;
                else
                {
                    e.CanExecute = false;
                    if ((BerserkerSkillPoints >= 10) || (ClericSkillPoints >= 10) || (DefenderSkillPoints >= 10) || (AssassinSkillPoints >= 10))
                        e.CanExecute = true;
                }
            }
            else
                e.CanExecute = false;
        }

        private void ResetSorcererTree_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SorcererSkillPoints == AllocatedSkillPoints)
                ResetAllSkillTrees();
            else
            {
                AllocatedSkillPoints -= SorcererSkillPoints;
                RemainingSkillPoints = MaxSkillPoints - AllocatedSkillPoints;
                SorcererSkillPoints = 0;
                ResetSorcererTabPoints();
                DisableSorcererTreeButtons();
                UpdateSkillsAvailability();
                UpdateDamageReductions();
            }
        }

        private void CaptureImage_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(571, 530, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(MainPage);
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image file (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == true)
                fileName = saveFileDialog.FileName;

            if (fileName == null)
                return;

            using (Stream fileStream = File.Create(fileName))
            {
                pngImage.Save(fileStream);
            }
        }

        private void UpdateDamageReductions()
        {
            int temp;

            int defTreeDamageReduction;
            defTreeDamageReduction = DamageReductionFromDefTree();

            // Net physical damage reduction
            temp = EndurancePoints * 2 + RepercussionPoints * 2 + PleasurePoints * 3 + ThornPoints * 3 +
                   DefenseMasteryPoints * 2 + ColdArmorPoints * 4 + defTreeDamageReduction;

            if (temp != PhysicalDamageReduction)
                PhysicalDamageReduction = temp;

            temp = EndurancePoints * 2 + RepercussionPoints * 2 + PleasurePoints * 3 + MindTrainingPoints * 3 +
                   DefenseMasteryPoints * 2 + ColdArmorPoints * 4 + defTreeDamageReduction;

            if (temp != MagicDamageReduction)
                MagicDamageReduction = temp;

        }

        private int DamageReductionFromDefTree()
        {
            if (DefenderSkillPoints >= 35)
                return 6;
            else if (DefenderSkillPoints >= 25)
                return 4;
            else if (DefenderSkillPoints >= 15)
                return 2;
            else
                return 0;
        }
        // END
        // Commands
    }

    public static class CustomCommands
    {
        // Command for resetting complete tree
        public static readonly RoutedUICommand ResetAllTrees = new RoutedUICommand("ResetAllTrees", "ResetAllTrees", typeof(MainWindow));

        // Command for resetting assassin's tree
        public static readonly RoutedUICommand ResetAssassinTree = new RoutedUICommand("ResetAssassinTree", "ResetAssassinTree", typeof(MainWindow));

        // Command for resetting berserker's tree
        public static readonly RoutedUICommand ResetBerserkerTree = new RoutedUICommand("ResetBerserkerTree", "ResetBerserkerTree", typeof(MainWindow));

        // Command for resetting cleric's tree
        public static readonly RoutedUICommand ResetClericTree = new RoutedUICommand("ResetClericTree", "ResetClericTree", typeof(MainWindow));

        // Command for resetting defender's tree
        public static readonly RoutedUICommand ResetDefenderTree = new RoutedUICommand("ResetDefenderTree", "ResetDefenderTree", typeof(MainWindow));

        // Command for resetting sorcerer's tree
        public static readonly RoutedUICommand ResetSorcererTree = new RoutedUICommand("ResetSorcerer", "ResetSorcerer", typeof(MainWindow));
    }
}
