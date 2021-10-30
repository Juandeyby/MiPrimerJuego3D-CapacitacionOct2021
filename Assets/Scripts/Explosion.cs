using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Vector3 _posicion;
    [SerializeField] private GameObject _enemigoPrefab;
    [SerializeField] public List<GameObject> _listaEnemigos;
    private GameObject _enemigoPadre;

    // Start is called before the first frame update
    void Start()
    {
        _listaEnemigos = new List<GameObject>();
        _posicion = transform.position;
        _enemigoPadre = new GameObject();
        _enemigoPadre.name = "Enemigo Padre";
    }

    // Update is called once per frame
    void Update()
    {
        CrearEnemigo();
        VerificarAltura();
    }

    private void CrearEnemigo()
	{
        if (Input.GetButtonDown("Jump"))
        {
            //Crear objeto
            var aleatorioX = Random.Range(-4.5f, 4.5f);
            var aleatorioZ = Random.Range(-4.5f, 4.5f);

            var enemigo = Instantiate(_enemigoPrefab, transform.position + new Vector3(aleatorioX, 3, aleatorioZ), Quaternion.Euler(0, 0, 0));
            _listaEnemigos.Add(enemigo);
            enemigo.transform.parent = _enemigoPadre.transform;
            enemigo.name = "Enemigo";
        }
    }

    private void VerificarAltura()
	{
        for (var i = 0; i < _listaEnemigos.Count; i++)
		{
            if (_listaEnemigos[i].transform.position.y < -6f)
			{
                _listaEnemigos[i].transform.position = new Vector3(_posicion.x, _posicion.y + 3, _posicion.z);
            }
		}
	}

	private void OnMouseDown()
	{
        foreach(var enemigo in _listaEnemigos)
		{
            var temporal = enemigo.GetComponent<Enemigo>();
            temporal.Explotar(_posicion);
        }
	}
}
