using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;
    private Explosion _explosion;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        if (GameObject.Find("Sphere"))
		{
            _explosion = GameObject.Find("Sphere").GetComponent<Explosion>();
        }
        StartCoroutine(RutinaCambiarColor());
    }

    private void CambiarColor()
	{
        _materialPropertyBlock = new MaterialPropertyBlock();
        var color = new Color(Random.value, Random.value, Random.value);
        _materialPropertyBlock.SetColor("_Color", color);
        _materialPropertyBlock.SetColor("_EmissionColor", color);
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explotar(Vector3 posicion)
	{
        _rigidbody.AddExplosionForce(10, posicion, 100, 10, ForceMode.Impulse);
    }

    private IEnumerator RutinaCambiarColor()
	{
        while(true)
		{
			CambiarColor();
            yield return new WaitForSeconds(4);
        }
		yield return null;
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
            var index = _explosion._listaEnemigos.IndexOf(gameObject);
            Destroy(_explosion._listaEnemigos[index]);
            _explosion._listaEnemigos.RemoveAt(index);
        }
	}
}
