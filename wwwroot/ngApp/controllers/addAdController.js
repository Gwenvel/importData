class AddAdController {
    constructor($adService, $categoryService, $state) {
        this.state = $state;
        this.adService = $adService;
        this.ad = this.newAd();
        this.categoryService = $categoryService;
        this.categories = this.categoryService.getCategories();
    }
    newAd() {
        return {
            adId: 0,
            title: "",
            description: "",
            price: 0,
            phone: "",
            timestamp: this.time(),
            street: "",
            city: "",
            state: "",
            zip: 0,
            email: "",
            activeId: "change me",
            categoryId: 1
        };
    }
    time(){
        var date = new Date();
       return date;
    }
    addAd() {
        this.adService.addAd(this.ad, res=> {
            this.state.reload();
        });
    }

    cancel() {
        this.state.go("home")
    }
}