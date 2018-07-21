using UnityEngine;
using UnityEngine.SceneManagement;

namespace DataContainer
{
	public class UnitOfWork : MonoBehaviour
	{
		public string LevelNumber { get; set; } = "1";
		public string PointNumber { get; set; } = "1";

	    public void Awake()
	    {
	        DontDestroyOnLoad(this.gameObject);
	    }
        private void Start()
	    {
	        LevelNumber = SceneManager.GetActiveScene().name.Replace("Scene", "").Replace("Level", "");
	    }

	}
}
