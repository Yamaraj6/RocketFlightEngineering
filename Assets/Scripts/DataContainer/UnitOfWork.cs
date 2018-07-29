using Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataContainer
{
	public class UnitOfWork : MonoBehaviour
	{
		public static string LevelNumber { get; set; } = "1";
		public static string PointNumber { get; set; } = "1";
	    public static string EngineNumber { get; set; } = "1";

	    public void Awake()
	    {
	        DontDestroyOnLoad(this.gameObject);
	    }
        private void Start()
	    {
	        LevelNumber = SceneManager.GetActiveScene().name.Replace("Level", "");
	    }

	    public void SetEngineNumber(string value)
	    {
	        UnitOfWork.EngineNumber = value;
	    }
	    public void SetPointNumber(string value)
	    {
	        UnitOfWork.PointNumber = value;
	    }
    }
}
