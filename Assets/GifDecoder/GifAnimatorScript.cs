/*  Copyright © 2016 Graeme Collins. All Rights Reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. The name of the author may not be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY GRAEME COLLINS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. */

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
