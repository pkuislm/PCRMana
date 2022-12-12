using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CriWare;
using CriWare.CriMana;

public class PageControl : Singleton<PageControl>
{

    public Image imageLayer;
    public List<MenuPage> pages;

    CriManaMovieControllerForUI movieLayer;
    CriAtomExPlayer bgmPlayer;
    string currentBGM;
    string currentMovie;
    Stack<MenuPage> pageStack;

    [SerializeField] GameObject NavBar;

    [SerializeField]
    GameObject pagePrefab;

    public void JumpToPage(int pageNum)
    {
        if(pageNum < pages.Count)
        {
            if (pageStack.Count > 0)
            {
                pageStack.Peek().OnSwapOut();
                foreach(var p in pageStack)
                {
                    if (p.isTemp) Destroy(p.gameObject);
                }
                pageStack.Clear();//Using Jump-to will clear all page history
            }
            SetPageMedia(pages[pageNum]);
            pages[pageNum].OnSwapIn();
            pageStack.Push(pages[pageNum]);
        }
    }

    public void EnterPage(int pageNum)
    {
        if (pageNum < pages.Count)
        {
            if (pageStack.Count > 0)
            {
                pageStack.Peek().OnSwapOut();
            }
            SetPageMedia(pages[pageNum]);
            pages[pageNum].OnSwapIn();
            pageStack.Push(pages[pageNum]);
        }
    }
    public void CreateAndEnterStoryDetailPage(int storyGroupId, string bg, string bgm, bool is_static, string title)
    {
        GameObject pageInstance = Instantiate(pagePrefab, gameObject.transform);
        

        MenuPage page = pageInstance.GetComponent<MenuPage>();
        StoryPlateController controller = pageInstance.GetComponent<StoryPlateController>();
        if (page == null || controller == null) throw new System.Exception("Cannot find existing component");

        page.isStatic = is_static;
        page.isTemp = true;
        if (is_static)
        {
            page.bg = bg;
            page.mov = "";
        }
        else
        {
            page.mov = bg;
            page.bg = "";
        }

        if (bgm == null)
        {
            page.bgm = currentBGM;
        }
        else
        {
            page.bgm = bgm;
        }
            
        page.SetTitle(title);

        if (pageStack.Count > 0)
        {
            pageStack.Peek().OnSwapOut();
        }

        SetPageMedia(page);

        controller.LoadMainStoryChaptersByStoryGroupId(storyGroupId, title);

        page.OnSwapIn();
        pageStack.Push(page);
    }

    public bool IsCurrentPage(int pageNum)
    {
        if (pageNum < pages.Count)
        {
            return pages[pageNum] == pageStack.Peek();
        }
        return false;
    }

    public void ReturnToPreviousPage()
    {
        if(pageStack.Count > 0)
        {
            var page = pageStack.Pop();
            page.OnSwapOut();
            if (page.isTemp) Destroy(page.gameObject);
            SetPageMedia(pageStack.Peek());
            pageStack.Peek().OnSwapIn();
        }
        else
        {
            Debug.Log("PageStack is empty");
        }
    }

    public void SetPageMedia(MenuPage page)
    {
        SetBGM(page);

        if (!page.isStatic && page.mov != currentMovie && movieLayer.player.status == Player.Status.Playing)
        {
            movieLayer.player.Stop();
        }
        else if(!page.isStatic && page.mov == currentMovie)
        {
            return;
        }

        if(!page.isStatic && page.mov != "")
        {
            movieLayer.player.SetFile(null, page.mov);
            movieLayer.player.Loop(true);
            movieLayer.Play();
        }
        else
        {
            movieLayer.player.Stop();
        }
    }

    void SetBGM(MenuPage page)
    {
        if(page.bgm == null || page.bgm == "")
        {
            bgmPlayer.Stop();
            currentBGM = "";
            return;
        }

        if(page.bgm != currentBGM)
        {
            bgmPlayer.Stop();
            bgmPlayer.SetCue(null, page.bgm);
            bgmPlayer.Start();
            currentBGM = page.bgm;
        }
    }

    bool GetCurrentPageMovieType()
    {
        //TODO: Add main page movie support
        return true;
    }

    public void StopAllMedia()
    {
        bgmPlayer.Stop();
        movieLayer.player.Stop();
        currentBGM = "";
        currentMovie = "";
    }

    public void Hide()
    {
        pageStack.Peek().OnSwapOut();
        NavBar.SetActive(false);
    }

    public void Show()
    {
        pageStack.Peek().OnSwapIn();
        NavBar.SetActive(true);
    }

    public void ResumeAllMedia()
    {
        SetPageMedia(pageStack.Peek());
    }

    Shader ShaderDispatch(MovieInfo movieInfo, bool additiveMode)
    {
        return Shader.Find(GetCurrentPageMovieType() ? "PCRMana/MenuPageMovieYuva" : "CriMana/SofdecPrimeYuv");
    }

    void Start()
    {
        movieLayer = GetComponent<CriManaMovieControllerForUI>();
        movieLayer.player.SetShaderDispatchCallback(ShaderDispatch);
        if (bgmPlayer == null)
        {
            bgmPlayer = new CriAtomExPlayer();
        }

        if (pageStack == null)
        {
            pageStack = new Stack<MenuPage>();
        }
        foreach(var i in pages)
        {
            i.GetComponent<CanvasGroup>().alpha = 0f;
        }
    }

    private void OnDestroy()
    {
        if(movieLayer != null)
        {
            movieLayer.player.Stop();
            movieLayer.player.Dispose();
        }
    }
}
