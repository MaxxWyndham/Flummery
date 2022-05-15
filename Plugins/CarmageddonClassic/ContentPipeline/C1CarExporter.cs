using System;
using System.Collections.Generic;

using ToxicRagers.Carmageddon.Formats;
using ToxicRagers.Carmageddon.Helpers;
using ToxicRagers.Helpers;

using Flummery.Core;
using Flummery.Core.ContentPipeline;

namespace Flummery.Plugin.CarmageddonClassic.ContentPipeline
{
    class C1CarExporter : ContentExporter
    {
        public override void Export(Asset asset, string path)
        {
            Model model = asset as Model;

            if (model.SupportingDocuments.ContainsKey("Car"))
            {
                ((Car)model.SupportingDocuments["Car"]).Save(path);
            }
            else
            {
                string name = ExportSettings.GetSetting<string>("CarName");

                Car car = new Car 
                { 
                    Name = $"{name}.TXT",
                    Stealworthy = true
                };

                car.ImpactTop = new ImpactSpec
                {
                    Description = "top",
                    Clauses = new List<ImpactSpecClause>
                    {
                        new ImpactSpecClause
                        {
                            Clause = "always",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.driver,
                                    Damage = 1.5f
                                }
                            }
                        }
                    }
                };

                car.ImpactBottom = new ImpactSpec
                {
                    Description = "bottom",
                    Clauses = new List<ImpactSpecClause>
                    {
                        new ImpactSpecClause
                        {
                            Clause = "always",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.transmission,
                                    Damage = 0.2f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z<0.25&x<0.25",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lf_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lf_brake,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.steering,
                                    Damage = 0.3f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z<0.25&x>0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rf_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rf_brake,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.steering,
                                    Damage = 0.3f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z>0.75&x<0.25",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lr_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lr_brake,
                                    Damage = 0.5f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z>0.75&x>0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rr_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rr_brake,
                                    Damage = 0.5f
                                }
                            }
                        }
                    }
                };

                car.ImpactLeft = new ImpactSpec
                {
                    Description = "left",
                    Clauses = new List<ImpactSpecClause>
                    {
                        new ImpactSpecClause
                        {
                            Clause = "z>0.25&z<0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.driver,
                                    Damage = 1f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z<0.25",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lf_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lf_brake,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.steering,
                                    Damage = 0.3f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z>0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lr_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lr_brake,
                                    Damage = 0.5f
                                }
                            }
                        }
                    }
                };

                car.ImpactRight = new ImpactSpec
                {
                    Description = "right",
                    Clauses = new List<ImpactSpecClause>
                    {
                        new ImpactSpecClause
                        {
                            Clause = "z>0.25&z<0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.driver,
                                    Damage = 1f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z<0.25",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rf_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rf_brake,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.steering,
                                    Damage = 0.3f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "z>0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rr_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rr_brake,
                                    Damage = 0.5f
                                }
                            }
                        }
                    }
                };

                car.ImpactFront = new ImpactSpec
                {
                    Description = "front",
                    Clauses = new List<ImpactSpecClause>
                    {
                        new ImpactSpecClause
                        {
                            Clause = "always",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.engine,
                                    Damage = 1f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.transmission,
                                    Damage = 0.3f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "x<0.25",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lf_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lf_brake,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.steering,
                                    Damage = 0.5f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "x>0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rf_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rf_brake,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.steering,
                                    Damage = 0.5f
                                }
                            }
                        }
                    }
                };

                car.ImpactBack = new ImpactSpec
                {
                    Description = "rear",
                    Clauses = new List<ImpactSpecClause>
                    {
                        new ImpactSpecClause
                        {
                            Clause = "always",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.transmission,
                                    Damage = 0.5f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "x<0.25",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lr_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.lr_brake,
                                    Damage = 0.5f
                                }
                            }
                        },
                        new ImpactSpecClause
                        {
                            Clause = "x>0.75",
                            Systems = new List<ImpactSpecClauseSystem>
                            {
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rr_wheel,
                                    Damage = 0.5f
                                },
                                new ImpactSpecClauseSystem
                                {
                                    Part = ImpactSpecClauseSystemPart.rr_brake,
                                    Damage = 0.5f
                                }
                            }
                        }
                    }
                };

                car.GridImages[0] = $"G{name}.PIX";
                car.GridImages[1] = $"G{name}F.PIX";
                car.GridImages[2] = $"G{name}.PIX";

                car.PixelmapsHiRes.Add($"{name}.PIX");
                car.PixelmapsLoRes.Add($"{name}.PIX");
                car.PixelmapsLoMem.Add($"{name}.PIX");

                car.MaterialsHiRes.Add($"{name}.MAT");
                car.MaterialsLoRes.Add($"{name}.MAT");
                car.MaterialsLoMem.Add($"{name}.MAT");

                car.Models.Add($"{name}.DAT");

                string bon = $"{name.Substring(0, Math.Min(name.Length, 5))}BON";
                string lod = $"{name.Substring(0, Math.Min(name.Length, 7))}X";

                // lod
                car.Actors.Add($"{lod}.ACT");
                car.ActorLODs.Add(8);
                car.Crushes.Add(new Crush());

                // main
                car.Actors.Add($"{name}.ACT");
                car.ActorLODs.Add(0);
                car.Crushes.Add(new Crush());

                // bonnet
                car.Actors.Add($"{bon}.ACT");
                car.ActorLODs.Add(-1);
                car.Crushes.Add(new Crush());

                car.SteerableWheels.Add(7);
                car.SteerableWheels.Add(8);

                car.LeftFrontSuspension[0] = 4;
                car.RightFrontSuspension[0] = 3;
                car.LeftRearSuspension[0] = 6;
                car.RightRearSuspension[0] = 5;

                car.DrivenWheels[2] = 2;
                car.DrivenWheels[3] = 1;

                car.NonDrivenWheels[0] = 10;
                car.NonDrivenWheels[1] = 9;

                car.Grooves.Add(new Groove
                {
                    Part = "FRPIVOT.ACT",
                    Mode = GrooveMode.constant,
                    PathType = GroovePathNames.straight,
                    PathMode = GroovePathMode.absolute,
                    PathPeriod = 3,                             // front right suspension
                    PathDelta = new Vector3(0, 1, 0),
                    AnimationType = GrooveAnimation.rock,
                    AnimationMode = GroovePathMode.absolute,
                    AnimationPeriod = 7,                        // first steerable wheel
                    AnimationAxis = GrooveAnimationAxis.y
                });

                car.Grooves.Add(new Groove
                {
                    Part = "FLPIVOT.ACT",
                    Mode = GrooveMode.constant,
                    PathType = GroovePathNames.straight,
                    PathMode = GroovePathMode.absolute,
                    PathPeriod = 4,                             // front left suspension
                    PathDelta = new Vector3(0, 1, 0),
                    AnimationType = GrooveAnimation.rock,
                    AnimationMode = GroovePathMode.absolute,
                    AnimationPeriod = 8,                        // first steerable wheel
                    AnimationAxis = GrooveAnimationAxis.y
                });

                car.Grooves.Add(new Groove
                {
                    Part = "RRWHEEL.ACT",
                    Mode = GrooveMode.constant,
                    PathType = GroovePathNames.straight,
                    PathMode = GroovePathMode.absolute,
                    PathPeriod = 5,                             // rear right suspension
                    PathDelta = new Vector3(0, 1, 0),
                    AnimationType = GrooveAnimation.spin,
                    AnimationMode = GroovePathMode.controlled,
                    AnimationPeriod = 1,                        // driven wheel
                    AnimationAxis = GrooveAnimationAxis.x
                });

                car.Grooves.Add(new Groove
                {
                    Part = "RLWHEEL.ACT",
                    Mode = GrooveMode.constant,
                    PathType = GroovePathNames.straight,
                    PathMode = GroovePathMode.absolute,
                    PathPeriod = 6,                             // rear left suspension
                    PathDelta = new Vector3(0, 1, 0),
                    AnimationType = GrooveAnimation.spin,
                    AnimationMode = GroovePathMode.controlled,
                    AnimationPeriod = 2,                        // driven wheel
                    AnimationAxis = GrooveAnimationAxis.x
                });

                car.Grooves.Add(new Groove
                {
                    Part = "FRWHEEL.ACT",
                    Mode = GrooveMode.constant,
                    AnimationType = GrooveAnimation.spin,
                    AnimationMode = GroovePathMode.controlled,
                    AnimationPeriod = 9,                        // non-driven wheel
                    AnimationAxis = GrooveAnimationAxis.x
                });

                car.Grooves.Add(new Groove
                {
                    Part = "FLWHEEL.ACT",
                    Mode = GrooveMode.constant,
                    AnimationType = GrooveAnimation.spin,
                    AnimationMode = GroovePathMode.controlled,
                    AnimationPeriod = 10,                        // non-driven wheel
                    AnimationAxis = GrooveAnimationAxis.x
                });

                bool usedActualPositions = false;

                ModelBone frwheel = model.FindBone("FRWHEEL.ACT");
                if (frwheel != null)
                {
                    usedActualPositions = true;

                    car.RFWheelPos = frwheel.CombinedTransform.ExtractTranslation();
                    car.NonDrivenWheelDiameter = frwheel.Mesh.BoundingBox.Max.Y;
                }

                ModelBone flwheel = model.FindBone("FLWHEEL.ACT");
                if (flwheel != null)
                {
                    car.LFWheelPos = flwheel.CombinedTransform.ExtractTranslation();
                }

                ModelBone rrwheel = model.FindBone("RRWHEEL.ACT");
                if (rrwheel != null)
                {
                    car.RRWheelPos = rrwheel.CombinedTransform.ExtractTranslation();
                    car.DrivenWheelDiameter = rrwheel.Mesh.BoundingBox.Max.Y;
                }

                ModelBone rlwheel = model.FindBone("RLWHEEL.ACT");
                if (rlwheel != null)
                {
                    car.LRWheelPos = rlwheel.CombinedTransform.ExtractTranslation();
                }

                car.BoundingBoxes.Add(new ToxicRagers.Carmageddon.Formats.BoundingBox
                {
                    Min = model.Root.Mesh.BoundingBox.Min,
                    Max = model.Root.Mesh.BoundingBox.Max
                });

                if (!usedActualPositions)
                {

                }

                car.Save(path);
            }
        }
    }
}
