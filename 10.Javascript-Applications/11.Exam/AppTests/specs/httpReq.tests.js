define(['chai', 'httpReq'], function (chai, httpReq){
    var expect = chai.expect;

    describe('#httpReq', function () {
        var url = 'http://jsapps.bgcoder.com/post';

        it('Check if there\'s any connection', function (done) {
            httpReq.getJSON(url)
                .then(function (posts) {
                    expect(posts).to.be.ok;
                    expect(posts).to.have.length.above(1);
                    done();
                });
        });
    });
});