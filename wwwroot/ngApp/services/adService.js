class AdService {
    constructor($resource, $stateParams) {
        let actions = {
            "update": {
                method: "PUT",
                URL: "/api/Ads/:id/body"
            },
        };
        this.adsResource = $resource("/api/Ads/:id", null, actions);
    }

    getAds() {
        return this.adsResource.query();
    }

    getAd(id) {
        return this.adsResource.get({ id: id });
    }

    editAd(id, ad, callback) {
        this.adsResource.update({ id: id }, ad, callback);
    }
    editToNull(id,ad,callback) {
        this.adsResource.update({ id: id },{'activeId': null}, ad, callback);
    }

    deleteAd2(id, callback) {
        this.adsResource.remove({ id: id }, callback);
    }

    addAd(ad, callback) {
        this.adsResource.save(ad, callback);
    }
}