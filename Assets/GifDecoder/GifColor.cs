public struct GifColor
{
    public int r;
    public int g;
    public int b;
    public int a;

    public GifColor(int r, int g, int b, int a)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }

    public override string ToString()
    {
        return "R: " + r + " G: " + g + " B: " + b + " A: " + a;
    }
}
