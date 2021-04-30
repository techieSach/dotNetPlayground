using System;
using System.Collections.Generic;
using System.Linq;

public class Chunk<T>
{
    private IEnumerable<T> source;
    private int chunkSize;
    private int numberOfChunks;
    private int currentChunkNumber;

    public Chunk(IEnumerable<T> source, int chunkSize)
    {
        this.source = source;
        this.chunkSize = chunkSize;

        this.Initialize();
    }

    private void Initialize()
    {
        int itemCount = this.source == null ? 0 : this.source.Count(); 

        ////default to max chunkSize so that only 1 chunk is created
        this.chunkSize = this.chunkSize == 0 ? itemCount : this.chunkSize;
        this.numberOfChunks = itemCount/this.chunkSize;

        if(this.numberOfChunks > 0){
            if(itemCount % this.chunkSize > 0 ){
                this.numberOfChunks++;
            }
        }

        this.currentChunkNumber =0;
    }

    public bool GetNextChunk()
    {
        return this.numberOfChunks-- > 0;
    }

    public IEnumerable<T> CurrentChunk()
    {
        var chunkedSource  = this.source.Skip(this.currentChunkNumber * this.chunkSize).Take(this.chunkSize);
        this.currentChunkNumber++;
        return chunkedSource;
    }
}

