using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;

public class GifAnimatorScript : MonoBehaviour 
{
    private SpriteRenderer _spriteRenderer;
    private int _frameCounter = 0;
    private float _timePerFrame = 1 / 15f;
    private float _timeAccumulator;
    private Stopwatch _stopwatch;

    public List<Sprite> sprites;

    private void createRenderer()
    {
        _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprites[0];
        _frameCounter = 0;
    }

    private void startStopwatch()
    {
        _stopwatch.Reset();
        _stopwatch.Start();
    }

    private void endStopwatch()
    {
        _stopwatch.Stop();
    }

    private void updateFrame()
    {
        _timeAccumulator += (float)_stopwatch.Elapsed.Milliseconds * 0.001f;

        if (_timeAccumulator >= _timePerFrame)
        {
            _frameCounter = (_frameCounter + 1) % sprites.Count;
            _timeAccumulator -= _timePerFrame;
        }
        _spriteRenderer.sprite = sprites[_frameCounter];
    }

    void Update()
    {
        endStopwatch();
        updateFrame();
        startStopwatch();
    }

    void Start()
    {
        _stopwatch = new Stopwatch();

        createRenderer();
    }
}
