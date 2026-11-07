using System;
using System.Collections.Generic;
using NetData;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;
using data;
using physics.data;
using physics.engine.entity;
using physics.engine.entity.indicator;
using physics.entity;
using physics.trace;
using share;

namespace SSJJPhysicsExtensions;

public class ComplexPySceneItweenEntityAdapter : PySceneObjectAdapater, IPySceneItweenMoveEntity, IPyEntity, IEntityIndicator, IPyItweenMoveEntity
{
	private bool _inited;

	private Dictionary<int, PeekabooItemTmpData> _peekData;

	private SceneItemBrush _localBrush;

	public ComplexPySceneItweenEntityAdapter(SceneObjectEntity scneObjectEntity, Dictionary<int, PeekabooItemTmpData> peekData)
		: base(scneObjectEntity)
	{
		_peekData = peekData;
	}

	public override bool IsAirPush()
	{
		return false;
	}

	public override CBrush GetBrush()
	{
		if (!_inited)
		{
			_localBrush = new SceneItemBrush();
			sceneObjectEntity.sceneObjectPyhsics.Brushs.Add(_localBrush);
			Vector3 vector = new Vector3(_peekData[0].MinX + _peekData[0].PosX, _peekData[0].MinY + _peekData[0].PosY, _peekData[0].MinZ + _peekData[0].PosZ);
			Vector3 vector2 = new Vector3(_peekData[0].MaxX + _peekData[0].PosX, _peekData[0].MaxY + _peekData[0].PosY, _peekData[0].MaxZ + _peekData[0].PosZ);
			_localBrush.mins.SetTo(vector[0], vector[1], vector[2]);
			_localBrush.maxs.SetTo(vector2[0], vector2[1], vector2[2]);
			_localBrush.SetNormalMin(_localBrush.mins);
			_localBrush.SetNormalMax(_localBrush.maxs);
			_localBrush.brushFlags |= DecalsProxy.GetSoftSurface(1);
			_inited = true;
		}
		UpdateBrush();
		return _localBrush;
	}

	public void UpdateBrush()
	{
		foreach (CBrush brush in sceneObjectEntity.sceneObjectPyhsics.Brushs)
		{
			if (brush is SceneItemBrush sceneItemBrush)
			{
				Vector3 eulerAngles = sceneObjectEntity.rotation.EulerAngles;
				sceneItemBrush.SetRotationX(eulerAngles.x);
				sceneItemBrush.SetRotationY(eulerAngles.y);
				sceneItemBrush.SetRotationZ(eulerAngles.z);
				sceneItemBrush.SetX(GetX());
				sceneItemBrush.SetY(GetY());
				sceneItemBrush.SetZ(GetZ());
				if (sceneItemBrush.IsEngineBrushUpdated())
				{
					sceneItemBrush.bmatrix.Identity();
					MatrixUtility.RotationMatrix(sceneItemBrush.GetRotationX(), Vector3D.X_AXIS, sceneItemBrush.bmatrix);
					MatrixUtility.RotationMatrix(sceneItemBrush.GetRotationY(), Vector3D.Y_AXIS, sceneItemBrush.bmatrix);
					MatrixUtility.RotationMatrix(sceneItemBrush.GetRotationZ(), Vector3D.Z_AXIS, sceneItemBrush.bmatrix);
					MatrixUtility.TranslationMatrix(GetX(), GetY(), GetZ(), sceneItemBrush.bmatrix);
					float[] normaMax = sceneItemBrush.GetNormaMax();
					float[] normaMin = sceneItemBrush.GetNormaMin();
					sceneItemBrush.mins.SetTo(normaMin[0], normaMin[1], normaMin[2]);
					sceneItemBrush.maxs.SetTo(normaMax[0], normaMax[1], normaMax[2]);
				}
			}
		}
	}

	public override WeEntity CreateEngineEntity(WeScene scene)
	{
		return new WeDefaultEntity(scene, GetId(), VectorTypeConverter.Unity2Ssjj(sceneObjectEntity.position.Origin), scene.IsSimulationEnabled(), 65535, isOverlappable: false);
	}

	public IList<CBrush> GetItemBrushList()
	{
		if (!_inited)
		{
			for (int i = 0; i < _peekData.Count; i++)
			{
				SceneItemBrush sceneItemBrush = new SceneItemBrush();
				sceneObjectEntity.sceneObjectPyhsics.Brushs.Add(sceneItemBrush);
				PeekabooItemTmpData peekabooItemTmpData = _peekData[i];
				Vector3 vector = new Vector3(peekabooItemTmpData.MinX + peekabooItemTmpData.PosX, peekabooItemTmpData.MinY + peekabooItemTmpData.PosY, peekabooItemTmpData.MinZ + peekabooItemTmpData.PosZ);
				Vector3 vector2 = new Vector3(peekabooItemTmpData.MaxX + peekabooItemTmpData.PosX, peekabooItemTmpData.MaxY + peekabooItemTmpData.PosY, peekabooItemTmpData.MaxZ + peekabooItemTmpData.PosZ);
				sceneItemBrush.mins.SetTo(vector[0], vector[1], vector[2]);
				sceneItemBrush.maxs.SetTo(vector2[0], vector2[1], vector2[2]);
				sceneItemBrush.SetNormalMin(sceneItemBrush.mins);
				sceneItemBrush.SetNormalMax(sceneItemBrush.maxs);
				sceneItemBrush.brushFlags |= DecalsProxy.GetSoftSurface(1);
			}
			_inited = true;
		}
		UpdateBrush();
		return sceneObjectEntity.sceneObjectPyhsics.Brushs;
	}

	public List<HitBoxBrush> GetHitBoxBrushList(double x, double y, double z, double rotationX, double rotationY, double rotationZ, bool isPointTrace)
	{
		throw new NotImplementedException();
	}
}
