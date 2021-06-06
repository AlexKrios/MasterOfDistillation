using Assets.Scripts.Ui.FullMenu.Common.Model;
using Assets.Scripts.Ui.FullMenu.Common.Part;
using Assets.Scripts.Ui.FullMenu.Common.Product;
using Assets.Scripts.Ui.FullMenu.Common.Quality;
using Assets.Scripts.Ui.FullMenu.Common.Tab;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.DI.Scene.Main.FullMenu
{
    public class FullMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<TabsGroup, TabsGroup.Factory>().FromFactory<TabsGroupFactory>();

            Container.BindFactory<ProductCell, ProductCell.Factory>().FromFactory<ProductCellFactory>();

            Container.BindFactory<PartCell, PartCell.Factory>().FromFactory<PartCellFactory>();
            Container.BindFactory<PartGroup, PartGroup.Factory>().FromFactory<PartGroupFactory>();

            Container.BindFactory<QualityButton, QualityButton.Factory>().FromFactory<QualityButtonFactory>();

            Container.BindFactory<ModelGroup, ModelGroup.Factory>().FromFactory<ModelGroupFactory>();
            Container.BindFactory<GameObject, ModelGameObject, ModelGameObject.Factory>().FromFactory<ModelGameObjectFactory>();
        }     
    }
}