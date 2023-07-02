using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MagneticObject : ChargableObject
{
	[Header("Magnetic Settings")]
	[SerializeField] private float _magnetDistance;
	[SerializeField] private AnimationCurve _magnetPowerCurve;
	[SerializeField] private float _lerpStep;
	[Space]
	[SerializeField] private bool _fixY;
	[SerializeField] private bool _fixX;
	[Space]
	[SerializeField] private MagneticObject[] _otherMagnets;

	private Rigidbody2D _rigidbody;

	private void Awake() =>
		_rigidbody = GetComponent<Rigidbody2D>();

	private void FixedUpdate()
	{
		Magnet();
	}

	private void Magnet()
	{
		if (Power == PowerType.No) return;

		var magnetPower = new Vector2(0, 0);

		foreach (var magnet in _otherMagnets) 
		{
            if (magnet.Power == PowerType.No) continue;

            var vector = (Vector2) (magnet.transform.position - transform.position);
			var distance = vector.magnitude;
			if (magnet._magnetDistance <= distance) continue;

			var normalized = vector.normalized;
			var force = normalized * GetPower(distance, magnet, this);

			if (Power == magnet.Power)
				magnetPower -= force;
			else
				magnetPower += force;
		}

		if (_fixX) magnetPower.x = 0;
		if (_fixY) magnetPower.y = 0;

		if (magnetPower.x == 0 && magnetPower.y == 0) return;

		_rigidbody.AddForce(magnetPower - _rigidbody.velocity);
		//_rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, velocity, _lerpStep);
	}

	private float GetPower(float distance, MagneticObject first, MagneticObject second)
	{
		float result = 0;
		if (distance <= first._magnetDistance)
			result += first._magnetPowerCurve.Evaluate(distance / first._magnetDistance);
		if (distance <= second._magnetDistance)
			result += second._magnetPowerCurve.Evaluate(distance / second._magnetDistance);

		return result;
	}

	protected override void SetMinus() { }
	protected override void SetPlus() { }
	protected override void SetNoPower() { }
}