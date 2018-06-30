using Managers.Meta;

namespace Managers.Buildings
{
	public class BuildingManager :IManager{
		public SaveInfo Save(SaveInfo saveInfo)
		{
			return saveInfo;
		}

		public void Load(SaveInfo saveInfo)
		{
			//TODO: Load this from save
			
		}

		public void InitialSetup()
		{
			
		}
	}
}
