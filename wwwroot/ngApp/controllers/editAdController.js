class EditAdController {
    constructor($adService, $stateParams, $state, $categoryService) {
        let id = $stateParams["id"];
        this.state = $state;
        this.adService = $adService;
        this.ad = $adService.getAd(id);
        this.ads = this.adService.getAds();
        this.id = id;
        this.categoryService = $categoryService;
        this.categories = this.categoryService.getCategories();
    }

    editAd() {
        this.adService.editAd(this.id, this.ad, res=> {
            this.state.reload();
        });
    }

    deleteAd(id,active) {
       /* if (confirm("Are you sure you want to delete this posting? This CANNOT be undone.") == true) {*/
        this.adService.editToNull(this.id,this.ad, res=> {
                this.state.go("home");
            });
      /*  } else {
            this.state.reload();
        }*/
    }

    cancel() {
        this.state.go("home")
    }
}