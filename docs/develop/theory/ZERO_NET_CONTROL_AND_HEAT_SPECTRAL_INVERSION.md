# Zero-net control and heat spectral inversion

## 1. Scope and provenance

At a collocated port, the energy of a zero-net terminal control records a time-centered Gramian. Its derivative recovers the average-minus-endpoint heat response by a positive operator square root. Exact data determine the visible positive-rate spectral measure. On positive-time windows the relative heat response has a dimension-free, sharp square-root modulus in uniform Gramian noise. Equal global heat traces can conceal distinct boundary responses, and even identical boundary responses can conceal different network topologies. In normalized finite relative-modular models, entropy is discontinuous without control of the small-rate logarithmic tail.

This volume uses the repository’s `generic-v1` claim format and append anchor. It draws on the ordinary proofs and independent audits dated 24 November 2026, summarized below. This volume was composed by Codex from those materials using the source-theories writing template. The input proofs and their independent reviews were produced in separate workspace tasks. The manuscript preparation replayed the rational certificate and compares the formal claim with the reviewed Lean source. The formal-stage citation in §3 names the single declaration corresponding to the claim lead. The analytic, geometric and entropy arguments are ordinary mathematics.

## 2. Ordered Gramian and exact inversion

Let $A\ge0$ be self-adjoint on a real or complex Hilbert state space and let $B$ be a bounded map from the Hilbert port space $U$ into the state space. The load is $Bp$ and the observation is $B^*$. Write $\mu(D)=B^*E_A(D)B$ for the positive operator-valued spectral measure and $K(t)=B^*e^{-tA}B$ for the collocated kernel. The initial state is zero, the constraint is $\int_0^T p=0$ in $U$, and the effort is $\int_0^T\|p\|^2$. The vector constraint imposes zero integral at each port.

After reversing time, the terminal map on the closed subspace of zero-mean inputs is $L_Tq=\int_0^T K(r)q(r)\,dr$. Put $M_T=T^{-1}\int_0^T K(r)\,dr$. Orthogonal projection onto the constraint subspace subtracts the mean, so $(L_T^*v)(r)=(K(r)-M_T)v$. Thus the Gramian and squared support function of the unit-effort outputs are

$$
W(T)=L_TL_T^*=\int_0^T (K(r)-M_T)^2\,dr,\qquad
\sup_{\|q\|_2\le1}\operatorname{Re}\langle v,L_Tq\rangle=\sqrt{\langle v,W(T)v\rangle}.
$$

Squaring and polarizing the support function recovers $W$ from the extended minimum effort. In finite port dimension $\operatorname{ran}W=\operatorname{ran}L_T$ by taking orthogonal complements of $\ker L_T^*$. On that range the minimum effort is $\langle y,W^\dagger y\rangle$, attained by $L_T^*W^\dagger y$. This control reaches $y$ and is orthogonal to $\ker L_T$, which proves minimality. The effort is infinite off the range. The support-function argument works in arbitrary port dimension and allows nonclosed range.

The integrals exist in operator norm as improper integrals at zero. The heat kernel is bounded by $\|B\|^2$ there and norm-continuous at positive times by the uniform bound on $\lambda e^{-t\lambda}$. With $P=\int_0^T K(r)\,dr=TM_T$, expansion retains the ordered cross terms $-PM_T-M_TP$. Hence

$$
\begin{aligned}
W(T)&=\int_0^T K(r)^2\,dr-TM_T^2,&
M_T'&=(K(T)-M_T)/T,\\
W'(T)&=K(T)^2-M_T^2-T(M_T'M_T+M_TM_T')\\
&=K(T)^2-K(T)M_T-M_TK(T)+M_T^2=(M_T-K(T))^2 .
\end{aligned}
$$

Since $F(T)=M_T-K(T)=\int\phi(T\lambda)\,\mu(d\lambda)$ with

$$
\phi(x)=\int_0^1 e^{-ux}\,du-e^{-x}=x\int_0^1 u e^{-ux}\,du,
$$

$F(T)$ is positive and is the unique positive square root of $W'(T)$. The function $\phi$ vanishes at zero and is strictly positive at every positive rate. Taking quadratic forms shows $\ker F(T)=\ker\mu((0,\infty))$. If $W(T)v=0$, the squared norm of $(K(r)-M_T)v$ integrates to zero and vanishes at $r=T$ by continuity. Conversely, on $\ker\mu((0,\infty))$ the response is constant in time. Thus $\ker W=\ker W'=\ker F$ at every positive horizon.

Integrate $M_T'=-F(T)/T$ and use $K=M_T-F$. For $0<t\le H$ this gives

$$
K(t)-K(H)=\int_t^H F(s)\,\frac{ds}{s}-F(t)+F(H).
$$

The spectral theorem gives $K(H)\to\mu(\{0\})$ strongly as $H\to\infty$, and the averages converge to the same limit. The limit is in norm for finite port dimension. Sending $H$ to infinity recovers the positive-rate Laplace curve with an improper integral in the same topology. The zero atom cancels identically and can be supplied by a calibrated $B^*B$, by subtracting the recovered positive-rate mass. For a connected lumped path of known total length $L$, it is $\mathbf 1\mathbf 1^*/L$ at distinct vertex ports. On any connected capacity graph with two distinct observed vertices, the off-diagonal of $K(0)$ is zero, so the common stationary entry is the negative of the corresponding off-diagonal positive-rate mass. For one port the ambiguity occurs physically. Capacities and conductance $(1/2,1/2,1/4)$ and $(1/3,1/6,1/9)$ on a single edge give $1+e^{-t}$ and $2+e^{-t}$ at the first vertex, hence identical effort curves.

For exact data on an open horizon interval, complexify real spaces when needed. The curve $W$ extends holomorphically to $\operatorname{Re}z>0$ by

$$
W(z)=z\left(\int_0^1 K(uz)^2\,du-\left(\int_0^1 K(uz)\,du\right)^2\right).
$$

Here $K(z)=B^*e^{-zA}B$ is holomorphic and bounded on the half-plane by spectral calculus. Truncating the $u$ integrals at $u=\varepsilon$ gives holomorphic terms converging locally uniformly as $\varepsilon\downarrow0$. The identity theorem therefore gives equality at all positive horizons from equality on the interval. For uniqueness of the positive-rate measure, push the difference of two candidates under $\lambda\mapsto e^{-\lambda}$ to $[0,1]$. Its scalar matrix elements integrate all positive powers to zero by the reconstructed transform at integer times, and integrate the constant to zero by the time-zero limit. Polynomial density determines each finite measure, hence the operator measure. Conversely, equal positive-rate measures leave only a constant difference in $K$, which vanishes upon centering. Finite networks have entire kernels and entire $W$. Exact continuation supplies uniqueness in this argument. The window estimate in §4 concerns a relative kernel on the observed time scale.

## 3. Formal endpoint first reveal

### 3.1 Statement

**Theorem 3.1.** Let $p,q$ be two paths of $n$ strictly positive edge lengths indexed by $0,\ldots,n-1$ from the marked endpoint. Suppose $0<k<n$, the lengths agree at every index $i<k$, and the lengths at index $k$ differ. For a path $p$, give each endpoint half the incident length as mass and each interior vertex half the sum of its incident lengths. With $M_p$ the diagonal mass matrix and $S_p$ the path stiffness with conductance reciprocal to edge length, put $J_p=M_p^{-1/2}S_pM_p^{-1/2}$ and $\mu_r(p)=(J_p^r)_{00}/m_0(p)$. In $\mathbb R[[X]]$ let $H_{p,c}=c+\sum_{r\ge0}(-1)^r\mu_r(p)X^r/r!$, where $c\in\mathbb R$, and let $\mathcal A$ divide the coefficient of degree $r$ by $r+1$. Put $\mathcal W(H)=X(\mathcal A(H^2)-(\mathcal A H)^2)$. For arbitrary independent real offsets $c,e$, the difference $D=\mathcal W(H_{p,c})-\mathcal W(H_{q,e})$ obeys

$$
[X^d]D=0\quad(d<2k+2),\qquad
[X^{2k+2}]D=-\frac{\mu_1(p)(2k)\big(\mu_{2k}(p)-\mu_{2k}(q)\big)}{(2k+2)!}\ne0 .
$$

### 3.2 Proof of the formal statement

Compress both normalized stiffness matrices to vertices $0,\ldots,k-1$, retaining their original diagonal entries. These compressions agree. The last retained diagonal uses the shared edge $k-1$, and each retained bond uses masses at retained vertices. A contribution to $(J^r)_{00}$ is a closed walk with steps of size at most one. A walk reaching $k$ takes at least $2k$ steps, and at length $2k$ there is exactly one, with $k$ steps out and $k$ back. All lower moments agree and the additional term at $2k$ is the product of the squares of the first $k$ bonds divided by the common $m_0$. If $\ell_i$ denotes the common length at index $i<k$, then the moment difference is

$$
\mu_{2k}(p)-\mu_{2k}(q)
=\frac{1}{m_0}
 \frac{\prod_{i=0}^{k-2}(J_p)_{i,i+1}^2}{\ell_{k-1}^2 m_{k-1}}
 \left(\frac1{m_k(p)}-\frac1{m_k(q)}\right).
$$

The empty product is one. Because $k<n$, $m_k$ is the interior mass averaging edge $k-1$ with the differing edge. The reciprocals differ and the prefactor is positive. The shared linear moment is $\mu_1=1/(\ell_0m_0^2)>0$.

The formal identity $(X\mathcal A G)'=G$ gives $X(\mathcal A H)'=H-\mathcal A H$. The product rule yields $\mathcal W(H)'=(\mathcal A H-H)^2$. A constant shift leaves $\mathcal A H-H$ unchanged and both Gramians have zero constant term. For $F_p=\mathcal A H_{p,c}-H_{p,c}$ and $F_q=\mathcal A H_{q,e}-H_{q,e}$, the derivative difference is $(F_p-F_q)(F_p+F_q)$. Its factors start in degrees at least $r=2k$ and $1$. Their coefficients at those degrees are $-r(\mu_r(p)-\mu_r(q))/((r+1)r!)$ and $\mu_1(p)$, respectively. Their product is the coefficient in degree $r+1$ of the derivative difference. Formal integration divides it by $r+2$ and fixes the constant at zero, proving the displayed formula and nonvanishing.

The formal-stage counterpart is `D5.S3.Quantum.Jacobi.NeumannHeatGramianJet.first_reveal`. Its endpoint truncation is `EndpointMomentTruncation.first_omitted_moment`. The reviewed scoped Lean report for implementation commit `01a5b8d17a09d3bc853d9353de90f39aca626a1f` records a successful build and report, with axiom closure `Classical.choice`, `Quot.sound` and `propext` for the declaration. The PR head `412bdf4b690c7d162a3f308698ba9b2a06641682` carries the frozen-state artifact and has the same Lean source. The power series statement concerns the nonempty common prefix and arbitrary offsets. Section 5 gives the ordinary analytic interpretation. [Lean source at PR head](https://github.com/the-omega-institute/trureturing/blob/412bdf4b690c7d162a3f308698ba9b2a06641682/D5/S3/Quantum/Jacobi/NeumannHeatGramianJet.lean#L304) · [PR #33867](https://github.com/the-omega-institute/trureturing/pull/33867)

## 4. Sharp stability on a positive-time window

The pairwise bound holds for every positive operator-valued measure on $[0,\infty)$ with bounded total operator, including compressed spectral measures with unbounded generator and arbitrary Hilbert port dimension. Take $0<a<H$ and $\delta=\sup_{[a/2,H]}\|W_1-W_2\|$. With $J_i(t)=K_i(t)-K_i(H)$, for $a\le t\le H$,

$$
\|F_1(t)-F_2(t)\|\le C\sqrt{\delta/t},\qquad
\|J_1(t)-J_2(t)\|\le C\sqrt{\delta}\left(3/\sqrt t-1/\sqrt H\right).
$$

The choice $C=2+840(3-q)/(1-q)^2$, with $q=2^{-1/3}$, is independent of rank, port dimension, spectral gaps and the total masses of the two measures. For scalar or jointly diagonal curves $C=8$ works. For observations within $\eta$ of an admissible curve, selecting any admissible fit within $\eta$ gives $\delta\le2\eta$ from the truth and the same error bound for its anchored response. This is a conditional stability estimate in the class of collocated heat curves. A calibrated $K(H)$ supplies an absolute value.

The mechanism is the relative Loewner bound $-F/t\preceq F'\preceq F/t$ and $-4F/t^2\preceq F''\preceq4F/t^2$. These follow by integrating $|x\phi'|\le\phi$ and $|x^2\phi''|\le4\phi$. In the scalar case set $S=F_1(t)+F_2(t)$ and $r=\sqrt{\delta/t}$. If $S\le r$, positivity gives the bound. Otherwise a backward slope over length $d=tr/(2S)\le t/2$ bounds $|(W_1-W_2)'(t)|$ by $2\delta/d+8S^2d/t$, using the relative first derivative bound on $[t-d,t]$. Divide by $S$ to obtain $8r$. In the operator proof, writing $G=W_1-W_2$ and $P_i=(I+F_i/L)^{-2}$ at scale $L\ge r$, one estimates $P_1G'P_2$ by a backward weighted mean with vanishing first moment. Integration by parts gives a noise cost $O(\delta/d+\delta/t)$ and the ordered product rule gives a bias $O(L^2 d^2/t^2)$. With $d=(t/2)(r/L)^{2/3}$, the sum is $O(L^{2/3}r^{4/3})$. Dyadic spectral projections of the two roots at the target time give cross blocks for the equation $F_1(F_1-F_2)+(F_1-F_2)F_2=G'$. At largest band scale $L$ the regularizers have bounded inverses on the bands and the Sylvester inverse costs $O(1/L)$. The block decay $O(r\,2^{-j/3})$ at band index $j$, with $2j+3$ blocks of that index, is summable in operator norm. The low–low block costs at most $2r$. The integral in §2 gives the kernel bound.

Sharpness already holds for a physical one-port, two-node network. Take capacities $1,m>0$ and conductance $\alpha m/(1+m)$ with port at the first vertex. Put $w=m/(1+m)$. Then $K_{\alpha,w}(t)=1-w+w e^{-\alpha t}$ and $W_{\alpha,w}'(t)=w^2\phi(\alpha t)^2$. For $\alpha=1,2$ and $w\downarrow0$, the Gramian and derivative gaps are of order $w^2$, and the gaps in $F$ and the anchored kernel on a nondegenerate window are of order $w$. The coefficient functions of these gaps are analytic and nonidentical, as seen from their expansions at zero. Midpoint data force an error at least half the kernel separation for one of the pair. Each Gramian has full port support and the rates stay in $[1,2]$. A second witness uses $m=1$ and compares rates $\rho,2\rho$ as $\rho\downarrow0$, keeping the visible weight fixed. Here $\phi(x)=x/2+O(x^2)$ gives Gramian separation of order $\rho^2$ and kernel separation of order $\rho$.

For direct derivative noise $\|W_1'-W_2'\|_\infty\le\epsilon$, positivity and operator monotonicity of the square root give $\|F_1-F_2\|\le\sqrt\epsilon$. Indeed each positive square is bounded above by the other plus $\epsilon I$, and $\sqrt{G+\epsilon I}\preceq\sqrt G+\sqrt\epsilon I$. The window formula gives $\sqrt\epsilon(2+\log(H/t))$. With a known common support and both roots bounded below there by $\gamma I$, the Sylvester integral gives $\epsilon/(2\gamma)$ for the root difference. This linear power for derivative noise is attained by varying one rate near a fixed positive rate with a nonzero derivative of the anchored kernel. The earlier absolute-derivative bounds for estimating $W'$ by finite differences give explicit but weaker uniform-$W$ rates under a mass bound. The relative argument above establishes the square-root endpoint for uniform-$W$ data. The modulus concerns heat on the window. Moving a fixed positive residue from $\lambda$ to $\lambda+\varepsilon$ gives arbitrarily close heat data with a fixed total-variation distance between the two visible measures.

## 5. Finite spectral and path recovery

### 5.1 Positive-rate Hankel realization

For $\mu_+=\sum_{j=1}^s C_j\delta_{\lambda_j}$ with distinct positive rates and nonzero positive matrix residues, let $S_i=\int\lambda^i\,d\mu_+$. The block Hankel matrix $(S_{i+j})_{0\le i,j<b}$ is the Gram matrix of the blocks $A_+^iB_+$ of the positive-rate realization. The shifted matrix $(S_{i+j+1})$ is the Gram form with $A_+$ inserted. Interpolation on the $s$ rates isolates each $E_A(\{\lambda_j\})B$, so the rank stabilizes by $b=s$ at $\sum_j\operatorname{rank}C_j$. Two consecutive equal ranks certify stabilization, since the common span is invariant under the generator. Quotient by the Gram kernel and use the shifted form as the matrix element of the reconstructed generator. Inserting the input in degree zero gives the collocated load. This recovers the minimal positive-rate realization up to port-preserving isometry. Every finite input-output realization must have at least the stabilized rank, since its Hankel matrix factors through its state space. The stationary residue, when supplied, adds its rank to the minimal dimension.

For a cap of $s$ positive rates on both candidates, $2s$ consecutive moments suffice by Lagrange interpolation on the union. To certify an $s$-atom target among positive measures with unrestricted support and the indicated finite moments, $2s+1$ suffice by integrating the square of the target’s annihilating polynomial, forcing support on its roots. Both counts are sharp. For $m$ ordered positive nodes $x_i$ and $Q(x)=\prod_i(x-x_i)$, the signed weights $1/Q'(x_i)$ annihilate degrees $0$ through $m-2$ by comparison of leading coefficients in interpolation. Splitting the alternating signs produces collisions for $m=2s$ and $m=2s+1$. The same arguments apply to moments starting at degree one by using $\lambda\,d\mu_+$. For rank alone under a cap $s$ on visible dimension, the sharp count is $2s-1$ in the worst case, allowing the zero law at $s=1$. The lower witness uses $m=2s-1$ nodes and the upper bound uses the Hankel rank at block size $s$.

In a finite model write $F(T)=\sum_{r\ge1}A_rT^r$ with $A_r=(-1)^{r+1}rS_r/((r+1)r!)$. The coefficient of $T^3$ in $W$ is $A_1^2/3$ and yields $A_1=S_1/2$ by the positive square root. On its support, each next coefficient of $W'$ gives $A_1A_r+A_rA_1$ after subtraction of the known terms. In an eigenbasis of $A_1$ this map divides entries by the sums of two positive eigenvalues when inverted. All $A_r$ vanish on the kernel by positivity of the residues. Thus $W$ through degree $b+2$ and the moments $S_1,\ldots,S_b$ determine each other. The two measure-identification counts give last degrees $2s+2$ and $2s+3$. These counts concern exact jets.

### 5.2 Marked lumped paths and sharp jet depths

For a finite path, the physical endpoint kernel with offset $c$ is $K(t)+c=m_0^{-1}(e^{-tJ})_{00}+c$. The exponential series converges locally uniformly, including after multiplication and averaging over the unit scaled time interval. Consequently §3 describes the Taylor coefficients of the analytic Gramian. Since $-K'(0)=4/\ell_0^3>0$, the actual scalar effort for any fixed nonzero target $y$ is $|y|^2/W(T)$. Its reciprocal gives the Gramian jet. The first-edge case follows from $[T^3]W=\mu_1^2/12=4/(3\ell_0^6)$. For a first change at index $k>0$, §3 yields a first absolute Gramian gap of degree $2k+2$. For the same pair the relative effort gap has order $T^{2k-1}$, by taking reciprocals with the common cubic leading term. The bounded relative errors of radius $\eta$ at one horizon make the two readings overlap exactly when $\eta\ge |W_p-W_q|/(W_p+W_q)$. Thus coalescing horizons have this relative discrimination scale even when the absolute effort gap diverges.

Keep $n,L$ fixed. The cubic recovers the first length, and as each further length is reached the first-return formula gives its reciprocal interior mass from the next selected coefficient. Specifically the common-prefix moments determine all lower terms in $[T^{2k+1}]F^2$, leaving the linear term $2A_1A_{2k}$ in the unknown moment. The last length follows from the sum. For $n\ge3$ the sparse list consists of the cubic and degrees $4,6,\ldots,2n-2$. For $n=2$ the cubic suffices, and for $n=1$ the length is already specified. Perturbing the last two lengths by opposite increments preserves all coefficients below $2n-2$ for $n\ge3$, or below the cubic for $n=2$. The $n-1$ scalar count is also minimal among continuous data maps by invariance of domain on the open length simplex. If $L$ is free at fixed $n\ge2$, one more step is necessary and sufficient, through degree $2n$. For one edge and free length, the cubic suffices. With unbounded $n$ there is no finite jet cutoff valid for every length vector at fixed $L$.

The exact positive-rate measure recovers a marked lumped path even with unknown edge count and total length. The endpoint vector is cyclic because each successive power $J^ie_0$ introduces vertex $i$ with the product of the first $i$ bonds as its nonzero entry. Consequently the number of visible positive rates equals the edge count. The first moment determines the first edge and hence $K(0)$. Subtracting the total positive-rate weight gives the stationary weight $1/L$. Orthogonalizing the endpoint powers with the reconstructed full measure recovers the Jacobi matrix with negative bonds. Its positive null vector gives all masses relative to $m_0$, and the bonds then give the conductances and lengths in the marked order.

## 6. Global traces and topology

### 6.1 Equal traces with strict boundary gaps

For a lumped path let $C$ take right-minus-left differences, let $D=\operatorname{diag}(\ell)^{-1/2}CM^{-1/2}$ and write $J=D^*D$, $G=DD^*$. The positive spectra coincide by the maps $D$ and $D^*/\lambda$ on the $\lambda$-eigenspaces, and $J$ has one extra zero. The following length-one witness has equal traces in both degrees and different ordered meshes even up to reversal.

Use four edges and fix $x_1=9/25$, $x_2=279/2000$ with one-based indexing. Write $z=(x_3,y_1,y_2,y_3)$ and complete both vectors to length one. If $a_i=(1/m_{i-1}+1/m_i)/\ell_i$ and $b_i=1/(m_i^2\ell_i\ell_{i+1})$, the characteristic polynomial of $G$ is obtained from $P_0=1$, $P_1=X-a_1$ and $P_i=(X-a_i)P_{i-1}-b_{i-1}P_{i-2}$. Let $f(z)$ be the four nonleading coefficients for $x$ minus those for $y$. The exact pair uses the unique zero of $f$ in the cube of radius $10^{-16}$ centered at the rational vector

$$
(0.411867180195067938755774546658,\
 0.407494358375467667844326708658,\
 0.033821168056731557146949179112,\
 0.351118664900040899673411760887).
$$

Writing $c$ for the center and $R=f'(c)^{-1}$, rational interval arithmetic verifies $\|Rf(c)\|_\infty<10^{-28}$ and $\sup\|I-Rf'(z)\|_\infty<10^{-6}$ on the cube. Thus $z\mapsto z-Rf(z)$ contracts the cube into itself. The fixed point gives exact spectral equality. All lengths exceed $3/100$ there, and $y_1>2/5$ exceeds both $x_1$ and $x_4$, with $x_4<1/10$. The separate small-path calculation recovers all paths with at most three edges at fixed total length up to reversal using the positive spectral invariants. Four is therefore the least edge count for this nonreflection collision.

A unit impulse at the physical left vertex gives $h(0+)=2/\ell_1$ and $-h'(0+)=4/\ell_1^3$. The unforced vertex equation gives the rightward first-edge flux $\Phi=m_0(-h')$. An $M$-normalized eigenvector $u$ at $\lambda>0$ has edge partner $du/\sqrt\lambda$, where $d=\operatorname{diag}(\ell)^{-1}C$, with first entry $-m_0\sqrt\lambda\,u(0)$. Summing its squares gives the raw degree-one diagonal kernel $h^1_{11}(t)=m_0^2(-h'(t))$. For the certified pair, the spectral bound $\lambda<5000$ follows from $S\preceq4M/(3/100)^2$ for stiffness $S$. Together with $1/m_0<6$ it gives $|h^{(j)}(t)|\le6\cdot5000^j$. The initial gaps for $x$ minus $y$ in $h,-h',\Phi,h^1$ are bounded below by $5/9,33875/1458,475/162,5/18$, respectively. Their derivative bounds are $60000,300000000,75000000,18750000$. Each gap stays strictly positive on $0<t\le10^{-8}$. On this range, $h_x(s)-h_x(t)>h_y(s)-h_y(t)>0$ for $0\le s<t$. Integrating the squares of those differences over the time square and dividing by $2T$ gives $W_x(T)>W_y(T)$ and strictly smaller effort for $x$ at every such horizon and nonzero target.

There is also a growing reflected family at a fixed physical left port. Fix $b\in(0,1)$ and use edge lengths $(bh,h,\ldots,h)$ and the reverse, with $h=L/(n-1+b)$. At $t=\tau h^2$ the marked vertex heat gap is $h^{-1}(c_b(\tau)+O(n^{-N}))$ for every fixed $N$, uniformly on compact scaled-time intervals. Here $c_b$ is the difference of the half-line kernels with and without the first-cell defect. In scaled Jacobi coordinates the operators have uniformly bounded norm and every fixed endpoint power agrees with its half-line analogue once the far boundary is outside the walk range. The exponential tail gives the stated error, including after any fixed number of scaled-time derivatives. Since $c_b(0)=2(b^{-1}-1)>0$, a fixed positive interval has a gap of order $h^{-1}$. The two traces remain equal by reflection. The signed endpoint heat gap has one crossing, while the short-left-cell path has strictly smaller squared zero-net effort at every positive horizon. The all-horizon comparison uses the positive primitive of the signed heat gap and the single sign change to order the centered roots $F$. This family quantifies the trace failure at the mesh time scale.

### 6.2 Equal full port heat on a path and a triangle

Take the path with lengths $(1/2,1/2)$, masses $M=\operatorname{diag}(1/4,1/2,1/4)$ and both conductances $2$. Its stiffness and a change of coordinates are

$$
S=\begin{pmatrix}2&-2&0\\-2&4&-2\\0&-2&2\end{pmatrix},
\qquad
U=\begin{pmatrix}1&0&0\\0&1/3&2/3\\0&4/3&-1/3\end{pmatrix}.
$$

Direct multiplication gives $U^*MU=M$, $U\mathbf1=\mathbf1$ and $U^*e_0=e_0$. The stiffness $S'=U^*SU$ has zero row sums and positive conductances $2/3,4/3,14/9$ on $01,02,12$. With the same masses and the same physical load at vertex $0$, the normalized generators are orthogonally conjugate by $M^{1/2}UM^{-1/2}$, which fixes $M^{-1/2}e_0$. Hence the full marked heat kernels agree, including the zero atom, and every zero-net effort agrees. Both port vectors are cyclic by the path argument and conjugacy. The graphs have two and three edges, respectively. Thus even full visibility and calibrated temperature data leave topology ambiguous in the class of positive-capacity networks.

For physical vertex ports with known masses, the recovered positive-rate measure determines the rows of conductive flux by $\Phi_{ij}(t)=-m_iK'_{ij}(t)$. At shift $z>0$, the full calibrated temperature response is $E^*(S+zM)^{-1}E$, where $E$ selects the ports. It is the Stieltjes transform of the full visible law. Its inverse is the dynamic Schur admittance obtained by eliminating the interior vertices. These observables inherit the stated identification scope of the port data.

## 7. Entropy of realized finite modular laws

### 7.1 A faithful product realization and a discontinuity

Every finite law $\mu=\sum P_j\delta_{\lambda_j}$ with $P_j,\lambda_j>0$, $\sum P_j=1$ and $\sum P_j\lambda_j=1$ is the visible relative-modular law of faithful product states. Set $Q_j=P_j\lambda_j$, fix a faithful retained qubit state $\tau$, and take $\rho=\tau\otimes\operatorname{diag}P$ and $\sigma=\tau\otimes\operatorname{diag}Q$. The physical vector is $\sqrt\rho$ in Hilbert–Schmidt space and the generator is $\Delta(X)=\sigma X\rho^{-1}$. Only diagonal matrix units carry weight for this vector, and summing the retained weights yields exactly the given visible support and masses. Both reduced states are $\tau$ under the environmental partial trace $\Phi$. Its Petz map for $\sigma$ sends $X$ to $X\otimes\operatorname{diag}Q$. The relative entropy loss $\mathcal L$ and the unhalved trace-norm recovery error $\mathcal B$ are therefore

$$
K(t)=\int e^{-t\lambda}\,d\mu,\quad
\mathcal L=D(\rho\Vert\sigma)-D(\Phi\rho\Vert\Phi\sigma)
=\int-\log\lambda\,d\mu,\quad
\mathcal B=\int|1-\lambda|\,d\mu .
$$

Choose distinct strictly positive binary probabilities $p,q$. Set $P=((1-\varepsilon)p,\varepsilon)$ and $Q_s=((1-s)q,s)$. Compare $s_i=\varepsilon e^{-c_i/\varepsilon}$ with $0<c_1<c_2$. The source state, retained state and partial trace are common to the two arms. With $D_0=D(p\Vert q)>0$, the entropy limits are $D_0+c_i$ because the flag contributes exactly $c_i$. The recovery error tends to $b=\|p-q\|_1>0$, so both $\mathcal B^2/\mathcal L$ and $\mathcal B/\sqrt{\mathcal L}$ have distinct limits in the two arms. The weighted sum of rate changes is $2|s_1-s_2|$, which bounds the kernel gap on $[0,H]$ after multiplication by $H$. Orthogonal centering gives a Gramian gap at most $2H$ times that kernel gap. The audit proves matching lower bounds of order $|s_1-s_2|$ for fixed nondegenerate interior windows, including anchored heat and the efforts for a fixed nonzero target. Thus the counterexample uses faithful states and a genuine partial trace, with three distinct visible rates for sufficiently small $\varepsilon$. The rates remain bounded above and the obstruction comes from the flag approaching rate zero.

The same family has an exact copy experiment. Measuring the diagonal flag count gives $\operatorname{Bin}(N,s_i)$, and conditional preparation reconstructs the product state from the count with an arm-independent channel. When $Ns_1\to w<\infty$ and $s_2/s_1\to0$, the equal-prior optimal error tends to $e^{-w}/2$. For $Ns_1\to\infty$ the error tends to zero. This determines the binary transition at reciprocal data gap, including for collective tests.

### 7.2 Sharp conditional entropy rates

On weakly convergent unit-mean laws with finite limiting entropy, the upper-rate logarithmic tail is uniformly negligible, since it is bounded beyond $R$ by $\sup_{x>R}(\log x)/x$. The remaining condition for entropy convergence is uniform integrability along the sequence of $(-\log\lambda)_+$. This follows by clipping at height $A$ and passing to the weak limit for the bounded continuous clipped function. A bound $\int(-\log\lambda)_+^{1+\gamma}\,d\mu\le M$ with $\gamma>0$ bounds the discarded part by $M A^{-\gamma}$.

For fixed $0<a<H$, that moment bound gives the sharp worst-case pairwise entropy modulus of order $(\log\log(1/\delta))^{-\gamma}$ over finite normalized modular laws of unrestricted atom count. Here $\delta$ bounds the kernel gap on $[a,H]$, including the gap modulo an additive constant, or the uniform Gramian gap there. On this class the fixed-target effort gaps on $[a,H]$ are equivalent to Gramian gaps because the moment budget forces a positive mass in a compact positive-rate band and hence a uniform lower bound for $W(a)$. The same upper modulus applies to both recovery scores on a fixed positive loss floor, with sharpness on the compatible classes supplied by the examples. In the fixed-base three-symbol family above with source held fixed in each comparison, the sharp order under a logarithmic moment bound is $(\log(1/\delta))^{-\gamma}$. Indeed the data gap is comparable to $|s-s'|$, and clipping the logarithm gives a residual bound of order $e^A|s-s'|$. Taking $s_i=\varepsilon e^{-c_i\varepsilon^{-1/(1+\gamma)}}$ attains the single-logarithm order.

For the unrestricted upper bound, the scalar relative-derivative argument gives an anchored heat gap of order $\sqrt\delta$ directly on $[a,H]$, using a one-sided step into the interval. For the anchored holomorphic difference $J$ bounded by $4$ on the right half-plane and bounded by $\eta$ on a closed subinterval $[b,c]\subset(a,H)$, a two-constants estimate gives $|J(t)|\le4e^{-\kappa t\log(4/\eta)}$ up to $H$. The harmonic comparison function is a multiple of $\int_b^c\log|(z+u)/(z-u)|\,du$. With $R=\log(4/\eta)$ and $n=\lfloor R^{1/3}\rfloor$, the sample errors at $jh$, $h=H/n$, are exponentially small in $R/n$. Unit mass and unit mean bound the residual absolute offset by $h$ plus the first sample error. For a degree-$n$ polynomial $P$ of $x=e^{-h\lambda}$ this offset is multiplied only by $P(1)-P(0)$. The Fejér approximant of the doubly clipped logarithm at height $A=(\log n)/2$ has supremum at most $A$, coefficient norm $O(nA7^n)$ and uniform error $O_H(n^{-1/4}\log n)$. The small sample errors absorb its coefficient norm. Removing the clip yields the stated double logarithm. The same approximation for $2(1-\lambda)_+$ controls $\mathcal B$ faster, giving the score bounds.

For sharpness, use two low rates $n^{-6},n^{-4}$ and subtract the signed interpolation correction on nodes $(1+j^2)/n^2$, $0\le j\le n$, to annihilate moments through $n$. In the coordinate $z=n^2\lambda-1$ the Lagrange basis at $j^2$ has derivative bounded on $[-1,0]$ by a constant for $j=0$ and by $C/j^2$ otherwise. The correction has total variation $O(n^{-2})$. The two normalized Jordan parts have matching moments and a logarithmic gap asymptotic to $2\log n$. Each must have more than $n/2$ atoms, since the square of an annihilating polynomial on a smaller support would distinguish the two parts within the matched degrees. Mix each with weight $\beta(\log n)^{-1-\gamma}$ into the same binary base, rescaling the common base rates to keep the means exactly one. The inserted part has bounded logarithmic moment and the loss gap has order $(\log n)^{-\gamma}$. A common faithful source realizes both arms by splitting the inserted source mass over pairs of support labels using product weights and selecting each arm’s rate from its own label. The common base cancels in the kernel difference, and the first $n$ moments cancel in the Taylor expansion with remainder bounded by a constant times $(2H)^{n+1}/(n+1)!$. With $n=\lceil\log(1/\delta)\rceil$ the Gramian and heat gaps are at most $\delta$ for sufficiently small $\delta$. The losses tend to $D_0$ and the error gap is of smaller order than the entropy gap, so the score moduli are sharp for these witnesses too.

## 8. Literature and verification scope

The ordered inverse, sharp Gramian noise modulus, finite jets, explicit isospectral and network witnesses, and finite modular laws above are derived in the accompanying research proofs. The core inverse reuses the Gramian range and supported inverse from trureturing’s `Observer/Dynamics/ControllabilityGramianReachableRange` and `Observer/Hilbert/FiniteMoorePenroseInverse` under `D5/S3`. The Hankel argument uses the existing Gram quotient for sampled heat and the classical realization method of Ho and Kalman. The marked-path inverse uses the endpoint Jacobi recurrence. The finite modular calculation follows the relative-modular convention of `CanonicalRelativeModularModel` and directly computes the physical laws and Petz error. The atom-count-growing entropy lower bound is a finite interpolation argument. [Ho–Kalman, 1966](https://doi.org/10.1524/auto.1966.14.112.545)

The spectral trace result concerns mass-lumped interval discretizations. The operator inverse assumes bounded collocated ports, so a continuum boundary distribution requires a separate admissibility argument. The topology witness concerns one observed vertex with positive conductances and capacities. Inverse results for weighted graphs under the Two-Points Condition have their own observation and geometric hypotheses. The entropy and risk results here concern faithful finite-dimensional product states and the displayed laws. General continuum inverse boundary problems, graph reconstruction under other geometric hypotheses, and modular problems beyond this finite setting lie outside these results. [Graph heat and random-walk inverse results](https://arxiv.org/abs/2101.10026) · [Graph inverse-spectral scope](https://arxiv.org/abs/2107.00494)

The independent audits checked the ordered multiplication, singular Gramian case, rational root certificate, formal coefficient and its indexing, and the normalized finite modular examples. The early derivative-noise audit preceded the later uniform-Gramian endpoint proof. The scope of the formal-stage evidence is the coefficient claim in §3. The reviewed scoped report SHA-256 is `0850dea4375431e0f894e2da94e85a50951c13cf7365d5f5ef96851ed9c84560`.

## 追加锚（本行以下为增补区）

## 9. Exact formal cubic, sparse readout and full jet

The endpoint first reveal of §3 landed in trureturing PR #33867 at `3082d5c8b569198f53df01cbda59d1ec76735cf2`. PR #33889 landed the cubic coefficient and sharp fixed-length jet inverse at `39e2a52a9b73bb72e8427ee5037c1803e1dded8f`. The latter uses the former for the case of a nonempty common prefix and gives the formal counterpart of the fixed-length exact-jet statements in §5.2. [#33867 merge](https://github.com/the-omega-institute/trureturing/commit/3082d5c8b569198f53df01cbda59d1ec76735cf2) · [#33889 merge](https://github.com/the-omega-institute/trureturing/commit/39e2a52a9b73bb72e8427ee5037c1803e1dded8f)

Use the ordered path $p\in\mathrm{Path}(n)$ of §3, with strictly positive lengths $\ell_i(p)$ indexed from the measured endpoint and total length $\mathcal L(p)=\sum_{i=0}^{n-1}\ell_i(p)$. Here $\mathrm{Path}(0)$ has the unique empty length vector of total zero. Write $w_d(p,c)=[X^d]\mathcal W(H_{p,c})$ for the coefficient of the real formal Gramian of §3. The definitions `readoutDegree` and `jetCutoff` are

$$
R(k)=\begin{cases}3&k=0,\\2k+2&k>0,\end{cases}
\qquad
D(n)=\begin{cases}0&n\le1,\\R(n-2)&n\ge2.\end{cases}
$$

[Path and heat definitions at the #33867 merge](https://github.com/the-omega-institute/trureturing/blob/3082d5c8b569198f53df01cbda59d1ec76735cf2/D5/S3/Quantum/Jacobi/NeumannHeatGramianJet.lean#L149-L177) · [Readout degree](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L63-L64) · [Jet cutoff](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L136-L137)

**Theorem 9.1 (Formal cubic coefficient, cubic_coefficient).** Let $n>0$ be a natural number, $p\in\mathrm{Path}(n)$ and $c\in\mathbb R$ arbitrary. Then $w_d(p,c)=0$ for every natural $d<3$, and $w_3(p,c)=4/(3\ell_0(p)^6)$. [Merged Lean declaration](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L44-L61)

**Theorem 9.2 (Formal sparse injectivity, sparse_injective).** Let $n$ be any natural number, $p,q\in\mathrm{Path}(n)$ and $c,e\in\mathbb R$ independently arbitrary. If $\mathcal L(p)=\mathcal L(q)$ and $w_{R(k)}(p,c)=w_{R(k)}(q,e)$ for every natural $k$ with $k+1<n$, then $p=q$ as ordered paths. [Merged Lean declaration](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L118-L134)

**Theorem 9.3 (Formal full-jet injectivity criterion, finite_jet_injective_iff).** Fix natural numbers $n,d$, a real $L>0$ and independently arbitrary $c,e\in\mathbb R$. The implication below holds for every $p,q\in\mathrm{Path}(n)$ if and only if $D(n)\le d$.

$$
\mathcal L(p)=L,\quad \mathcal L(q)=L,\quad
\bigl(w_j(p,c)=w_j(q,e)\text{ for every natural }j\le d\bigr)
\quad\Longrightarrow\quad p=q.
$$

[Merged Lean declaration](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L184-L204)

## 10. Proof of the formal cutoff and its analytic interpretation

For the cubic, the formal identity of §3 gives $\mathcal W'=F^2$ with $F=\mathcal A H-H$ and $[X]F=\mu_1/2$. Since $[X^0]F=0$ and $[X^0]\mathcal W=0$, the coefficients below degree three vanish and the cubic is $\mu_1^2/12$. At the marked endpoint $m_0=\ell_0/2$ and $(J)_{00}=1/(\ell_0m_0)$, so $\mu_1=4/\ell_0^3$. The arbitrary constant offset drops out of $F$. [Merged cubic proof](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L25-L61)

If two ordered paths first differ at edge $k=0$, the positive first lengths give distinct cubics by strict monotonicity of $4/(3\ell_0^6)$. If $k>0$, §3 gives the first nonzero difference at $R(k)=2k+2$ for the two independent offsets. Thus sparse equality forces agreement on the first $n-1$ edges when $n\ge2$, and equal total length forces equality on the last edge. For $n=1$ the total supplies the sole length, and for $n=0$ the empty vector is unique. For $n\ge2$, the largest selected degree is $R(n-2)$, so a full jet through $D(n)$ contains every sparse readout. [Merged first reveal](https://github.com/the-omega-institute/trureturing/blob/3082d5c8b569198f53df01cbda59d1ec76735cf2/D5/S3/Quantum/Jacobi/NeumannHeatGramianJet.lean#L301-L311) · [Merged upper bound](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L118-L144)

For the lower bound with $n\ge2$, take $a=L/(n+1)$ and the path with $n-1$ edges of length $a$ followed by one of length $2a$. Swap the final two edges to obtain the second path. Both have positive lengths and total $L$, and their first difference is exactly at $k=n-2$. Every degree below $R(n-2)$ agrees for arbitrary independent offsets, while degree $R(n-2)$ separates the pair. The cutoff is therefore $3$ for $n=2$ and $2n-2$ for $n\ge3$. For $n=1$ it is $0$, and the implication for $n=0$ is vacuous at positive total. [Merged swap witness and cutoff proof](https://github.com/the-omega-institute/trureturing/blob/39e2a52a9b73bb72e8427ee5037c1803e1dded8f/D5/S3/Quantum/Jacobi/NeumannHeatGramianInverse.lean#L146-L204)

The Lean declarations concern real formal power series and equality of their coefficients. In the ordinary finite-path model with $n\ge1$, the physical load is $e_0u(t)$ in $M\dot z+Sz=e_0u(t)$ and the collocated reading is $z_0$. With $b=M^{-1/2}e_0$ the impulse response with offset is $H(t)=b^\top e^{-tJ}b+c$. Substituting $t=sT$ with $s\in[0,1]$ gives the ordinary Gramian

$$
W(T)=T\left(\int_0^1 H(sT)^2\,ds-\left(\int_0^1 H(sT)\,ds\right)^2\right).
$$

The matrix exponential and its products converge locally uniformly on bounded time sets, justifying termwise integration. Averaging divides each coefficient by its degree plus one, giving the formal $w_d(p,c)$ as the ordinary Taylor coefficients of $W$. For a fixed known nonzero target $y$, zero-net projection of the control gives the minimum squared effort $E(T)=Q/W(T)$ with $Q=|y|^2$. The heat has slope $-\mu_1<0$ at zero, so $W(T)>0$ for every $T>0$. Exact effort determines the analytic Gramian germ by taking $Q/E(T)$ and using analytic uniqueness on a positive open interval or along horizons accumulating at zero. The stationary weight of the physical kernel is $1/L$ at known total length. An arbitrary additive kernel offset cancels from $W$. The convergence, control interpretation and stability estimates use the calibrated analytic model.

## 11. Ordinary short-window log-effort stability and collapsing cells

### 11.1 Sharp rate on a compact positive class

Fix $n\ge2$, $0<a<b$ and $na<L<nb$. Let $K=\{\ell\in[a,b]^n:\sum_i\ell_i=L\}$, using the calibrated port and fixed known nonzero target of §10. Use one-based lengths here, with independent coordinates $x_j=\ell_j$ for $1\le j\le r=n-1$. Put $G(\ell,T)=\log(T^3E_\ell(T)/Q)=-\log(W_\ell(T)/T^3)$, with its continuous extension at $T=0$. For $\varepsilon>0$ let $D_\varepsilon(\ell,\ell')$ be the norm of the difference of these log data over horizons $T=\varepsilon s$, using either the supremum over $0<s\le1$ or the maximum over $r$ fixed distinct points $s\in(0,1]$. Set $\alpha_1=0$, $\alpha_j=2j-3$ for $2\le j\le r$, and $p=\alpha_r$. For sufficiently small $\varepsilon>0$, uniformly for pairs in $K$ and $\delta\ge0$,

$$
D_\varepsilon(\ell,\ell')\asymp
\sum_{j=1}^r\varepsilon^{\alpha_j}|x_j-x_j'|,
\qquad
\sup_{\substack{\ell,\ell'\in K\\D_\varepsilon(\ell,\ell')\le\delta}}\|\ell-\ell'\|_\infty
\asymp \min\{\operatorname{diam}_\infty K,\delta/\varepsilon^p\}.
$$

The constants can depend on $K$ and the chosen observations. The worst exponent is $2n-5$ for $n\ge3$, and $0$ for $n=2$. The known-length one-cell class has zero inverse modulus.

Indeed $W/T^3$ extends analytically near zero with positive value $A=4/(3\ell_1^6)$, uniformly on $K$. The cubic gives $\partial_{x_1}G=6/\ell_1+O(T)$. For $j\ge2$ put $k=j-1$ and $q=2k$. The compression in §3 determines the Gramian coefficients below degree $q+2$ from earlier edges. At degree $q+2$ the part depending on $x_j$ is $-\mu_1qP_j/(m_0(q+2)!m_k)$, with $P_j>0$ the prefix product in §3 excluding $1/m_0$ and $m_k=(\ell_{j-1}+\ell_j)/2$. Therefore $\partial_{x_j}G=T^{\alpha_j}(U_j+O(T))$, where $U_j=-\mu_1qP_j/(2A m_0(q+2)!m_k^2)$. Each leading derivative has constant sign and magnitude bounded away from zero on $K$.

Integrate these derivatives along the segment joining the meshes. The leading data difference is a linear combination of $s^{\alpha_j}$ whose coefficient magnitudes are comparable to $\varepsilon^{\alpha_j}|x_j-x_j'|$. The remainder has norm bounded by $O(\varepsilon)$ times their sum. The monomials are independent both on the window and on the $r$ positive sample points. In the latter case, a nonzero sum of $r$ distinct powers has at most $r-1$ positive zeros, by division by its smallest power and induction using Rolle’s theorem. Equivalence of norms in this finite-dimensional span and absorption of the remainder give the weighted bound. The worst weight gives the upper inverse bound, since the dependent coordinate is controlled by the sum of the independent differences. Varying only $x_r$ from an interior point along a fixed positive-length segment, with the last length compensating, gives the matching lower bound.

### 11.2 Loss of uniform inversion at cell collapse

For $n\ge3$ choose positive $a_0,b_0,c_4,\ldots,c_n$ summing to $L$. Compare the meshes $(a_0,h,b_0-h,c_4,\ldots,c_n)$ and $(a_0,b_0-h,h,c_4,\ldots,c_n)$ as $h\downarrow0$. Their mesh distance tends to $b_0$. For every finite $H>0$ their full-window log data have distance at most $C_Hh$ uniformly for $0<\varepsilon\le H$. Thus the entire positive fixed-length simplex for $n\ge3$ has no uniform inverse modulus tending to zero, even on a fixed full window.

In mass-scaled coordinates each arm has $J_h=h^{-1}w_hw_h^\top+B_h$, where $w_h=M_h^{-1/2}(e_i-e_{i-1})$ for the collapsing edge $i$ and $B_h$ is the bounded contribution of the other edges. A vanishing terminal mass is incident only to the collapsing edge. The calibrated port lies in $w_h^\perp$ because the first length is fixed and the collapsing edge is elsewhere. The component of $e^{-tJ_h}b$ along the unit vector of $w_h$ starts at zero and has damping at least $c/h$ for some $c>0$. Contractivity bounds the forcing from the orthogonal component, keeping the damped component $O(h)$. Variation of constants in the orthogonal component then bounds the heat error relative to the compressed generator by $O(ht)$. That compression identifies the endpoints of the removed edge, adds their masses and keeps the other stiffness terms. Its normalized matrix differs by $O(h)$ from the common reduced path with cells $(a_0,b_0,c_4,\ldots,c_n)$. The exponential difference contributes another $O(ht)$ on $[0,H]$. Centering the heat gives an $O(hT)$ difference of the functions $\overline H(T)-H(T)$, each of size $O(T)$ by the spectral bound $|H'(t)|\le\mu_1=4/a_0^3$. Integrating the difference of their squares using $W'=(\overline H-H)^2$ gives an $O(hT^3)$ Gramian gap to the reduced path. The reduced $W/T^3$ is positive on $[0,H]$, so the logarithm preserves the uniform $O(h)$ estimate.

The short-window rate and the collapse argument were independently checked in ordinary mathematics in the research audit *Independent audit of sharp zero-net effort jets and short-time mesh stability*, §§3–4.

## 追加锚（本行以下为增补区）

## 12. A Lean-frozen order gap at four calibrated ports

**Theorem 12.1 (Exact linear and physical orders).** Take four labeled ports and four hidden vertices, all of unit mass. Give each pair on the same side conductance $\epsilon=1/1000$ and use the port-to-hidden conductance matrix

$$
A=\begin{pmatrix}1&0&0&1\\1&1&0&0\\0&1&1&0\\0&0&1&1\end{pmatrix}+\epsilon\mathbf 1\mathbf 1^\top .
$$

Let $S_*$ be the resulting conductance Laplacian and $E$ the port insertion. The full calibrated kernel $K_*(t)=E^\top e^{-tS_*}E$ has minimum linear order seven among finite real matrix realizations $C e^{-tR}B$ and minimum physical order eight among finite conductance networks with the same labeled unit-mass ports, arbitrary positive hidden masses and nonnegative conductances. These orders include the stationary mode. For any such physical candidate with mass-normalized generator $S$, write $U_j=E^\top S^jE$ and $Q(S)=U_2-U_1^2$. The condition $|Q(S)_{ij}-Q(S_*)_{ij}|\le1/250$ for every port pair certifies only the physical lower bound of eight vertices.

The port space plus the hidden hyperplane orthogonal to $(1,-1,1,-1)^\top$ is invariant under $S_*$. Restriction gives seven linear states. The four columns of $E$ and the first three columns of $S_*E$ are independent, as seen from the first three hidden rows of the latter columns. Their Gram is a rank-seven principal section of the moment Hankel matrix, which factors through the state space of any exact realization. Equality of heat curves fixes the moments by differentiation at zero.

Block multiplication gives $Q(S)=(-S_{PH})(-S_{PH})^\top$ for the port-to-hidden block $S_{PH}$. At the target the entries of $Q$ are $2+q$ on the diagonal, $1+q$ on cycle edges and $q$ on opposite pairs, where $q=4\epsilon+4\epsilon^2=1001/250000$. Throughout the defect band the diagonals are at most $4$, the cycle entries at least $1$ and the opposite entries strictly below $1/36$. A nonnegative factor with at most three columns has entries at most $2$. Each cycle edge then has a column with both endpoints at least $1/6$. Two edges must use the same column, contributing at least $1/36$ to an opposite entry. Thus there are at least four hidden vertices. The complete target attains eight.

The quantitative factor argument extends the classical triangle-free cycle support argument credited to Naomi Shaked-Monderer. The Lean declarations `cycle_gram_width` and `cycle_heat_order_gap` are frozen at the merge of PR #33916. [Shaked-Monderer, *Bounding the CP-rank by graph parameters*](https://doi.org/10.13001/1081-3810.3009) · [Merged PR](https://github.com/the-omega-institute/trureturing/pull/33916) · [Lean](https://github.com/the-omega-institute/trureturing/blob/4248548adc929a1ce1175238def85699e87af85c/D5/S3/Combinatorics/SpectralGraph/FourPortHeatRealization.lean) · [Blueprint](https://github.com/the-omega-institute/trureturing/blob/4248548adc929a1ce1175238def85699e87af85c/Blueprint/D5/S3/Combinatorics/SpectralGraph/FourPortHeatRealization.md) · [Frozen state](https://github.com/the-omega-institute/trureturing/blob/4248548adc929a1ce1175238def85699e87af85c/Golden/Frozen/state/D5/S3/Combinatorics/SpectralGraph/FourPortHeatRealization.lean.json)

## 13. Ordinary two-port order and short-horizon tests

### 13.1 A single rational target

Use $\epsilon$ and $q$ from §12, now with two labeled unit-mass ports and four hidden coordinates. Add $\epsilon\mathbf 1$ to each of $(1,1,0,0)^\top$, $(0,1,1,0)^\top$, $(0,0,1,1)^\top$ and $(1,0,0,1)^\top$ to obtain $x,y,u,v$, respectively. Set

$$
\begin{gathered}
X=[x,y],\quad P=uu^\top+vv^\top,\quad D=4I-P,\quad r=x+y,\quad s=u+v,\\
g=D^{-1}r=\frac r4+\frac{1+2q}{4(1-2q)}s,\qquad
C=\begin{pmatrix}1+x^\top g&-1\\-1&1+y^\top g\end{pmatrix},\qquad
S=\begin{pmatrix}C&-X^\top\\-X&D\end{pmatrix}.
\end{gathered}
$$

With $z=(1,1,g^\top)^\top>0$ and $Z=\operatorname{diag}(z)$, the masses are the diagonal entries of $Z^2$ and the conductance Laplacian is $ZSZ$. Indeed $Sz=0$ and every off-diagonal entry of $S$ is strictly negative. This specifies a complete rational six-vertex network.

Its full kernel has minimum linear order five and minimum physical order six, with the same calibration and physical conventions as §12. The vectors $x,y,s$ span the hidden hyperplane perpendicular to $(1,-1,1,-1)^\top$. It is $D$-invariant and $Pr=(1+2q)s$. Thus $[E,SE,S^2E]$ spans the five-dimensional visible space, giving both a restriction and a rank-five Hankel bound. Any physical candidate of order at most five matching all the heat moments must have exactly five vertices. Identifying the Krylov columns by their Gram matrices gives a port-preserving isometry that intertwines the generators by shifting the powers of $S$. It transfers $\lambda_{\max}(D|_{\mathrm{span}(x,y,s)})=4$ to the candidate's hidden block $D'$. Then $P'=4I-D'$ is entrywise nonnegative, by positive semidefiniteness on the diagonal and the physical signs off the diagonal. The Gram of $x',y',P'y',P'x'$ equals that of $x,y,Py,Px$. Its diagonal is at most $(1+2q)^2(2+q)<4$, its cycle entries are at least $1$ and its opposite entries are $2q(1+q)<1/36$. The four-column obstruction of §12 excludes a factor on three hidden coordinates. By §2, exact $W$ on a positive open interval recovers the full $K$ within the calibrated physical class since $K(0)=I_2$. The same physical minimum applies to those effort data.

### 13.2 First separating moments

All alternatives below have at most five vertices, positive masses, the same labeled unit-mass ports and nonnegative conductances. In the free-total-mass class, matching the target through $U_4$ is impossible. Those moments fix the Gram of $[E,SE,S^2E]$ and give a port-preserving isometry intertwining $S$ on the span of $[E,SE]$. After identifying the hidden spaces with the target's visible hidden space, $X$ is fixed and the only possible change in $D$ is $D'=D+\alpha nn^\top$, where $n$ is a unit normal to $x,y$ there. The port edge is fixed by $C$ and full visibility excludes a component disjoint from both ports. Thus $D'$ is positive definite by Dirichlet energy. With $g'=D'^{-1}r$, conservation gives $X^\top g'=X^\top g=C\mathbf 1$, hence

$$
0=r^\top(g'-g)=-\alpha(n^\top g)(n^\top g').
$$

Here $n^\top g\ne0$ by the formula for $g$. If $n^\top g'=0$, then $Dg'=r$ and $g'=g$, a contradiction. Thus $\alpha=0$ and the exact obstruction applies.

For a five-vertex match through $U_3$, use $x'=(1,b,0)^\top$, $y'=(0,b,1)^\top$, $b=\sqrt{1+q}$. Give $D'$ eigenvalues $3,\beta,f$ on $(1,0,-1)^\top$, $(1,0,1)^\top$ and $(0,1,0)^\top$, respectively. Put $A_r=r^\top Dr$, $R_r=r^\top D^{-1}r$ and choose

$$
f=\frac{A_r-2\beta}{4b^2},\qquad
\frac2\beta+\frac{4b^2}{f}=R_r,\qquad 1<\beta<3.
$$

The left side crosses $R_r$ on $[1,3]$, with $f>3$ there. This follows from $21.95<A_r<22.1$ and $2<R_r<2.03$. The construction keeps $C$, $X^\top X$ and $X^\top D X$. The sum coupling has the prescribed squared norm and direct and inverse quadratic forms, and the difference coupling has eigenvalue $3$. These forms give the first three moments by block multiplication. The positive hidden ground vector is $(1/\beta,2b/f,1/\beta)^\top$.

With total mass fixed to $2+g^\top g$, matching through $U_3$ is already impossible. The moments $U_1,U_2$ and the mass fix the Gram of $[X,g]$, which has rank three. The third moment fixes $X^\top D X$, and $Dg=X\mathbf 1$ fixes the other blocks of $[X,g]^\top D[X,g]$. The resulting isometry intertwines the hidden blocks on their visible spaces, implying the excluded exact match. To match through $U_2$, reuse the two columns $x',y'$ above and put $a=1/(1-2q)$ and $h=g^\top g=31376127001/30751504002$. Here $C\mathbf 1=a\mathbf 1$. Choose $w\in(1/4,1/2)$ with $2(a-bw)^2+w^2=h$, which exists by opposite signs of the difference at the endpoints. Then $g'=(a-bw,w,a-bw)^\top>0$ gives the required Gram of $[X',g']$. Rotate the plane of $(1,0,1)^\top$ and $(0,1,0)^\top$ slightly to increase the first direction's coordinate in both columns while retaining positive coordinates of $g'$. Both coupling columns become strictly positive. Using masses $g_i'^2$, port-to-hidden conductances $g_i'X'_{ij}$, port edge $1$ and any fixed strictly positive hidden conductances gives a complete same-mass match.

### 13.3 Sharp noise scales and observation counts

Observe the full matrix $W(t)$ of §2 at horizons $0<t\le T$, with additive error of norm at most $\delta$ per observation in a fixed matrix norm. Set $k=6$ for free total mass and $k=5$ for the target's known total mass. For any fixed finite operator-norm cap on the alternatives' normalized generators and any fixed $k-2$ distinct fractions in $(0,1]$, there exist $c,T_0>0$ such that the maximum observation distance from the target is at least $cT^k$ for every alternative and $0<T\le T_0$. Noise below half that separation permits uniform discrimination. When the class admits the matching alternative from §13.2, the pair has distance $O(T^k)$ uniformly on $[0,T]$. Its pointwise midpoint gives identical transcripts under either hypothesis for any finite adaptive design at $\delta\ge C T^k$, forcing maximal error at least $1/2$ even with randomization. This gives the sharp noise exponents.

Writing $W_j=[t^j]W(t)$, the identity $W'=(\overline K-K)^2$ uses the coefficient $(-1)^{j+1}jU_j/((j+1)j!)$ of $t^j$ in $\overline K-K$. Hence $W_3=U_1^2/12$. For successive higher coefficients through $W_k$, the newly appearing moment enters by a nonzero multiple of its anticommutator with $U_1$. At the target $U_1$ is positive definite, so the Sylvester map is invertible. The coefficient vector $(W_3,\ldots,W_k)$ stays a positive distance from the capped alternative class. Otherwise a convergent subsequence of candidate matrices would match the prohibited moments. In the free-mass limit, rank five of the Hankel matrix forces full visibility. The positive ground vectors with port entries one cannot diverge, since normalizing a diverging subsequence would yield a nonzero nonnegative kernel vector vanishing at the ports. By the off-diagonal signs, its positive support would be a separate invisible block. The limiting ground vector is strictly positive by the same support argument. At fixed mass the ground vectors are bounded from the outset, and a zero hidden ground coordinate in the limit forces the corresponding row of $[X,g]$ to vanish, contradicting rank three. The weighted Vandermonde matrix on the chosen fractions now carries the coefficient gap to the data, with least singular value bounded below by a constant times $T^k$ and uniform remainder $O(T^{k+1})$.

For free mass a cap of at least $7$ admits a complete local matching family. In the orthonormal sum and middle hidden directions insert off-diagonal $-\sqrt{2}\eta$ in the $\beta,f$ block and set $f=(A_r-2\beta+8b\eta)/(4b^2)$. This retains the direct form $A_r$. Varying $\beta$ smoothly retains the inverse form $R_r$, since at $\eta=0$ its derivative in $\beta$ is $-2/\beta^2+2/f^2<0$. A small $\eta>0$ makes all hidden conductances positive. The rotation of §13.2, applied also to the hidden block by conjugation, makes both port couplings positive. The initial matching generator has norm below $7$, leaving slack for both changes.

To vary the moments near this complete match, prescribe nearby $(C,G,J)$ with $G=X^\top X$ and $J=X^\top D X$ and choose $X$ smoothly from its Gram. In the orthonormal frame of $XG^{-1/2}$ and its normal, the leading block of $D$ is $V=G^{-1/2}JG^{-1/2}$. Keep the last diagonal $d>0$ fixed and set $\nu=G^{-1/2}C\mathbf 1$, $\omega=V\nu-G^{1/2}\mathbf 1$. Conservation requires the cross block $\xi$ to satisfy $\xi\xi^\top\nu/d=\omega$. Its smooth solution is $\xi=\pm\sqrt d\,\omega/\sqrt{\nu^\top\omega}$ with the base sign. At the base $\nu^\top\omega>0$ because the ground vector has nonzero normal coordinate, which holds before perturbation since $\beta<f$ and persists for small changes. The strict signs persist, and the moment formulas and invertible Sylvester maps give free variation of $(W_3,W_4,W_5)$. At fixed mass, the positive definite Gram of $[X',g']$ admits positive factors for nearby blocks $X'^\top X'$ and $C\mathbf 1$ with its last entry fixed to $h$. Using those factors and the same hidden conductances gives free variation of $(W_3,W_4)$ under any cap strictly above the complete matching base's norm.

For all sufficiently small $T$, any $k-3$ distinct horizons in $(0,T]$ can be matched exactly within the corresponding local family. The Newton divided differences of $W(t)/t^3$ at those nodes give the free coefficient vector plus an $O(T)$ error in value and first parameter derivative, uniformly even for clustered nodes. This follows by the mean-value formula for divided differences. Solving against the target divided differences by contraction gives the match. For any deterministic adaptive design with at most $k-3$ queries, use the nodes on its exact target transcript. The matching network reproduces that transcript. Under the stated cap slack, the minimum deterministic exact count is therefore four for free mass and three at fixed mass.

One randomized query uses $t=aT$ with $a$ uniform on $[1/2,1]$ and accepts within $\delta$ of the target at that time. The type I error is zero. Uniformly for alternatives within the cap and fixed before the draw, with noise allowed to depend on the realized horizon, the type II error is at most

$$
\min\{1,C(\delta/T^k+T)^{1/(k-3)}\}.
$$

Indeed, dividing the true difference by $a^3T^k$ gives a polynomial in $a$ of degree at most $k-3$ plus $O(T)$. Some scalar entry polynomial has a coefficient uniformly bounded away from zero by the coefficient gap. Acceptance puts that entry in a sublevel set of size $O((\delta/T^k+T)^{1/(k-3)})$. Lagrange interpolation at $k-2$ points spaced proportionally to the measure of the set gives this bound. Thus for every fixed positive error tolerance one query allows noise proportional to $T^k$ for sufficiently small $T$. With exact data and any fixed finite alternative, the zero set of a nonzero analytic entry of the difference has measure zero, so this one-query test has zero error without a common cap.

### 13.4 Uniform visible spectral tails

The uniform upper guarantees also hold for a class of these alternatives with uniform integrability of the fourth visible moment for free mass or the third for fixed mass. For an orthonormal eigenbasis with rates $\lambda_j$ and port projections $v_j$, the precise condition for $m=4$ or $3$, respectively, is

$$
\lim_{L\to\infty}\ \sup_S\ \sum_{\lambda_j>L}\lambda_j^m\|v_j\|^2=0 .
$$

The trace weights sum to two. The Taylor remainder of $e^{-u}$ through degree $m$ is bounded by $C_m u^m\min(u,1)$ for $u\ge0$. Splitting the spectral sum at $L$ gives a uniform $o(t^m)$ heat remainder. Centering cancels $U_0$ and the centered kernel is $O(t)$ on a window of length $t$, so squaring in product order and integrating gives a uniform $o(T^{m+2})$ Gramian remainder. To retain the coefficient gap, a coefficient-matching sequence with an escaping eigenvalue would lose a rank-one term from its limiting rank-five Gram. At free mass the term comes from $(v_j,\lambda_j v_j,\lambda_j^2 v_j)$ and vanishes by the fourth visible tail. At fixed mass use the Gram of $[E,SE,z]$ and the term from $(v_j,\lambda_j v_j,\langle e_j,z\rangle)$, where $e_j$ is the eigenvector. Its ground coordinate is zero at every positive rate, and the visible coordinates vanish as the rate escapes. In both cases at most four terms remain, a contradiction. A bounded subsequence is excluded by the preceding compactness argument.

Consequently the fixed designs still separate by at least $cT^k$ with $k=m+2$, and the random-horizon bound has a uniform $o(1)$ in place of $T$. The sharp lower noise bound requires the class to contain the matching alternative, and the deterministic count obstruction requires it to contain the corresponding local family.

The two-port arguments above have independent mathematical review and exact rational replay of the underlying network. Lean formalization is pending and research priority remains unverified.

## 追加锚（本行以下为增补区）

## 14. Unrestricted two-port separation and statistical experiments

The exact order statement of §13.1 and the free-mass obstruction through $U_4$ in §13.2 are now formalized for the rational target. The Lean declaration `D5.S3.Combinatorics.SpectralGraph.TwoPortHeatRealization.exact_order_gap` proves stationary-inclusive Hankel and minimum linear order five, minimum physical order six, and the physical obstruction to matching all of $U_0,\ldots,U_4$. [Merged PR #33943](https://github.com/the-omega-institute/trureturing/pull/33943) · [Lean at merge cafdf6e69893f0728a0890878db457a8abe70d84](https://github.com/the-omega-institute/trureturing/blob/cafdf6e69893f0728a0890878db457a8abe70d84/D5/S3/Combinatorics/SpectralGraph/TwoPortHeatRealization.lean)

### 14.1 Sharp separation without a spectral restriction

**Theorem 14.1.** Keep the six-vertex target $S_*$ and its total mass $M=92879135005/30751504002$. Let $S$ range over all physical networks with at most five vertices, the same two labeled unit-mass ports, arbitrary positive hidden masses and nonnegative conductances, including disconnected networks. Use the actual full zero-net-current Gramian of §2 and any fixed matrix norm. Set $(d,k)=(4,6)$ for free total mass and $(d,k)=(3,5)$ when total mass equals $M$. For every fixed $0<a_1<\cdots<a_d\le1$ there exist $c,T_0>0$ such that

$$
\max_{1\le i\le d}\|W_S(a_iT)-W_*(a_iT)\|\ge cT^k
\qquad(0<T<T_0)
$$

simultaneously for every such $S$, even if chosen as a function of $T$. Both classes allow arbitrarily large generators and visible moments without a uniform spectral-tail condition. The same conclusion at fixed mass consequently holds at any four fixed distinct fractions. In each mass regime a single fixed physical competitor from §13.2 satisfies $\sup_{0\le t\le T}\|W_S(t)-W_*(t)\|\le C T^k$ for small $T$.

### 14.2 Moment recovery in the presence of large rates

Write $A_j=v_jv_j^\top$ for the port weight of an eigenvector of $S$ at rate $\lambda_j\ge0$. The weights sum to $I_2$. With $H(a)=(\overline K_{aT}-K(aT))/(aT)$ and $G(a)=W(aT)/T^3$,

$$
H(a)=\sum_j\lambda_j A_j\int_0^1 u e^{-aT\lambda_j u}\,du,
\qquad G'(a)=a^2H(a)^2.
$$

All $(-1)^rH^{(r)}$ are positive semidefinite and $H(b)\preceq(a/b)^2H(a)$ for $0<b\le a$. The trace $f=\operatorname{tr}(H^2)$ is completely monotone by the product rule and positivity of the trace of a product of two positive matrices.

Assume a sequence $T\downarrow0$ of competitors with data errors $o(T^k)$. For $a_0=0$, choose a linear combination $L(f)=\sum_{i=1}^d c_i\int_{a_{i-1}}^{a_i}a^2 f(a)\,da$ annihilating polynomials through degree $d-2$. The weighted moment minors are integrals of strictly positive Vandermonde determinants, so the cofactor weights alternate. Interpolation at $a_1,\ldots,a_{d-1}$ makes all signed remainders have the same sign and gives $|L(f)|\ge c_0(-1)^{d-1}f^{(d-1)}(a_d)$ with $c_0>0$. At the fixed target $f_*^{(d-1)}=O(T^{d-1})$, so $L(f_*)=O(T^{d-1})$. The measured increments of $G$, including $G(0)=0$, give the same bound for $L(f)$ for $(d,k)=(4,6)$ or $(3,5)$. On $[a_1,a_d]$, monotonicity bounds $\|H\|$ using $\operatorname{tr}G(a_1)$, and $H(a)^2\preceq C H(a_d)$. The increment $G(a_d)-G(a_1)$ has a positive definite limit proportional to $U_{1,*}^2$. Hence $H(a_d)\succeq\kappa I$ for some $\kappa>0$. The product rule bounds $\operatorname{tr}((-1)^{d-1}H^{(d-1)}(a_d))=O(T^{d-1})$.

Split rates at $T\lambda_j=1$, writing $U_r^{\rm slow}$ for the moments summed over $T\lambda_j\le1$. The derivative multiplier for order $l=d-1$ is $\lambda_j(T\lambda_j)^l\int_0^1 u^{l+1}e^{-a_d T\lambda_j u}\,du$. It bounds a constant times $T^l\lambda_j^{l+1}$ on slow rates, and on fast rates bounds a constant times $\lambda_j/(T\lambda_j)^2$ by restricting the integral to $u\le1/(T\lambda_j)$. Thus $\operatorname{tr}U_d^{\rm slow}=O(1)$ and $H_{\rm fast}=O(T^{d-1})$ uniformly on $[a_1,a_d]$. Taylor expansion there gives

$$
H(a)=\frac{U_1^{\rm slow}}2
       -\frac{aT U_2^{\rm slow}}3
       +\frac{a^2T^2 U_3^{\rm slow}}8
       +O(T^3)
$$

for four observations, or the linear truncation with $O(T^2)$ remainder for three. Integrate the ordered expansion of $H^2$ against $a^2$ over the $d-1$ intervals after $a_1$. Their weighted moment matrix is invertible. The constant coefficient gives the positive square root and the successive coefficients, divided by the corresponding powers of $T$, give invertible Sylvester equations at $U_{1,*}/2$. This recovers $U_r^{\rm slow}\to U_{r,*}$ for $1\le r\le d-1$.

For free mass the limiting shifted Hankel matrix with blocks $[U_{1,*},U_{2,*};U_{2,*},U_{3,*}]$ is positive definite of rank four. Indeed it is the Gram of $S_*^{1/2}[E,S_*E]$ and $[E,S_*E,z_*]$ is independent by the hidden frame $[x,y,g]$. An escaping positive-rate mode is either omitted from the slow Gram or contributes squared row norm $(\lambda_j+\lambda_j^3)\|v_j\|^2=O(1/\lambda_j)$ by the fourth-moment bound. With at least one zero mode, at most three positive-rate rows remain. This contradicts the limiting rank four. Generators along the proposed sequence must therefore be bounded, and the bounded four-horizon separation in §13.3 contradicts its assumed errors.

The four-horizon argument also gives the fixed-mass fifth power directly. For errors $o(T^5)$, the same interpolation with $d=4$ yields $T^3\operatorname{tr}U_4^{\rm slow}=o(T^2)$ and $H_{\rm fast}=o(T^2)$ on the positive observation interval. In the quadratic expansion of $H$, Hölder's inequality with weights $\lambda_j\|v_j\|^2$ and variable $T\lambda_j$ gives linear and quadratic coefficients $o(T^{2/3})$ and $o(T^{4/3})$. This controls the higher products in the square by $o(T^2)$ and again recovers the first three slow moments. The rank-four shifted Hankel limit excludes every fast mode. The calibrated Gram of $[E,SE,z]$, with $Sz=0$, $E^\top z=\mathbf1$ and $z^\top z=M$, now converges to the rank-five target Gram. A remaining escaping slow mode has zero ground coordinate and squared row norm $(1+\lambda_j^2)\|v_j\|^2=O(1/\lambda_j)$ by the bounded third moment, contradicting rank five. The bounded fixed-mass theorem applies to the resulting sequence.

### 14.3 Three horizons at fixed mass

With three observations, the first two slow moments converge and the third slow moment is bounded, as above. If all fast visible weights tend to zero, the slow calibrated Gram of $[E,SE,z]$ converges to the rank-five target Gram. Any escaping row is absent or vanishes by the third-moment bound. A bounded subsequence is already excluded by §13.3. Hence along a subsequence there is a fast atom with $w=\|v_j\|^2$ bounded away from zero. With the three cofactor weights chosen with signs $(+,-,+)$, each trace pair term in $f$ has nonnegative interpolation functional by complete monotonicity. The fast atom's self term on the first interval is therefore $O(T^2)$ because its later interval integrals are $O(T^4)$. This first integral equals

$$
\frac{w^2}{T^3\lambda_j}\int_0^{a_1T\lambda_j}
 b^2\left(\int_0^1 u e^{-bu}\,du\right)^2 db.
$$

The integral is bounded below on $T\lambda_j>1$, forcing $\lambda_j\ge cT^{-5}$.

Pass to a subsequence with fixed vertex count and converging eigenbasis. Let $P$ project onto the limiting finite-rate modes, $R$ be their generator, $B=PE$ and $z$ the limiting ground vector. The first two finite-rate moments equal $C=U_{1,*}$ and $U_{2,*}$ since the omitted slow escaping contributions vanish. Also $Pz=z$, $Rz=0$, $B^\top z=\mathbf1$ and $\|z\|^2=M$. Choosing times $s\downarrow0$ with $s\lambda_j\to\infty$ for all escaping rates makes $e^{-sS}\to P$. The off-diagonal signs of $S$ make $e^{-sS}$ entrywise nonnegative, by shifting $-S$ by a scalar diagonal before expanding the exponential. Hence $P$ is entrywise nonnegative. Each nonzero support block of this symmetric nonnegative projection has rank one by Perron–Frobenius. Positive definiteness of $C$ puts the projected ports in different blocks, so $B^\top B=\operatorname{diag}(b_1,b_2)$.

In the Gram of $[B,RB,z]$ the positive definite lower block is $\operatorname{diag}(U_{2,*},M)$ and the Schur complement is

$$
A=\operatorname{diag}(b_1,b_2)-C U_{2,*}^{-1}C-M^{-1}\mathbf1\mathbf1^\top.
$$

Its off-diagonal is nonzero by the rational evaluation below, forcing rank at least four for $P$. There are exactly five states and a single escaping eigenvector with limit $u$, so $P=I-uu^\top$. Nonnegativity implies $u_i u_j\le0$ for $i\ne j$. The visible escape, the diagonal port block and $C\succ0$ force its support to contain just one port and one hidden coordinate. By target symmetry take that port to be the first, so $b_2=1$. Put $A_*=I-CU_{2,*}^{-1}C-M^{-1}\mathbf1\mathbf1^\top$. The rank-one Schur complement $A$ annihilates $h=(A_{*,22},-A_{*,12})^\top$. With $\gamma=U_{2,*}^{-1}Ch$, the projection residual gives $Bh=RB\gamma+z(\mathbf1^\top h/M)$. Applying $B^\top R^2$ yields

$$
U_{2,*}h=U_3^{\rm finite}\gamma,qquad U_3^{\rm finite}=B^\top R^3B.
$$

The escaping atom's initial layer contributes $O(T^2)$ to $G$ since $\lambda_j\ge cT^{-5}$. Its ordered mixed terms with the finite-rate response are $O(T^3)$ because $a^2\|H_j(a)\|\le C/(T^2\lambda_j)$. Its self term differs from the integral over $[0,\infty)$ by $O(T^6)$ at each positive observation fraction. After division by $T^2$ it thus has a common subsequential limit proportional to $e_1e_1^\top$ at the three observations. The finite-rate part of $G$ has coefficients at $a^3,a^4T,a^5T^2$ respectively

$$
\frac{U_1^2}{12},\qquad
-\frac{U_1U_2+U_2U_1}{24},\qquad
\frac{U_1U_3+U_3U_1}{80}+\frac{U_2^2}{45},
$$

using its actual finite-rate moments, with uniform remainder $O(T^3)$. A functional of the three values annihilating $a^3,a^4$ and nonzero on $a^5$ eliminates the lower-order differences before taking limits. Since the assumed errors in $G$ are $o(T^2)$, for some scalar $s$ we obtain

$$
U_3^{\rm finite}=U_{3,*}-s\mathcal L_C^{-1}(e_1e_1^\top),
\qquad \mathcal L_C(Y)=CY+YC.
$$

The two equations are incompatible for this target. In the orthonormal symmetric and antisymmetric port basis indexed by $+,-$, let $p=125000/123999$ and use $q$ from §12. The eigenvalue pairs of $C,U_{2,*},U_{3,*}$ are respectively

$$
c=(p,p+2),\qquad m_i=c_i^2+d_i,\qquad
n_i=c_i^3+2c_id_i+j_i,
\quad d=(3+2q,1),\quad j=(4d_+-(1+2q)^2,3).
$$

Write $r_+=1-2/M-c_+^2/m_+$ and $r_-=1-c_-^2/m_-$. Direct rational evaluation gives $-72/10000<(r_+-r_-)/2=A_{*,12}<-70/10000$. Rescale $h$ and $\gamma$ in this basis by $\sqrt2$, giving coordinates $h=(r_-,r_+)$ and $\gamma_i=c_i h_i/m_i$. The preceding equations require proportionality of the vectors with coordinates

$$
v_i=n_i\gamma_i-m_i h_i,
\qquad w_i=\sum_{j\in\{+,-\}}\frac{\gamma_j}{2(c_i+c_j)}.
$$

Exact rational arithmetic gives the determinant

$$
v_+w_--v_-w_+
=-\frac{114045645488209846090976452240541508027266971504950645694164014592577566137505033999}
{306736230930913013601872935583335745259128781992517186192615538933660287252187437500000}
\in\left(-\frac{38}{100000},-\frac{36}{100000}\right).
$$

This excludes the fast regime and completes the three-horizon contradiction. All contradictions rule out sequences with normalized errors tending to zero, which establishes the uniform quantifiers of Theorem 14.1.

### 14.4 Deterministic, Gaussian and random observations

With additive noise bounded by $\delta$ in a fixed matrix norm at every observation, the $d$ fixed horizons of Theorem 14.1 discriminate uniformly for $2\delta<cT^k$. The fixed matching competitor gives identical midpoint replies under either hypothesis at every $0<t\le T$ when $\delta\ge C T^k$ for a sufficiently large constant. This forces maximal error at least $1/2$ for any finite adaptive experiment, including randomized ones. The local matching families of §13.3 are admitted in the unrestricted classes. For sufficiently small $T$ they match any $d-1$ exact positive horizons at most $T$, even clustered ones, including the nodes on a deterministic policy's target transcript. The minimum deterministic exact query counts are therefore four for free mass and three for fixed mass.

For $N\ge d$ full-matrix readings, add independent centered Gaussian noise of covariance $\sigma^2 I_3$ in Frobenius-isometric symmetric vectorization. Average balanced repetitions at the $d$ separating horizons and accept within half the guaranteed separation of the target stack. The Gaussian norm tail bounds both errors by $\min\{1,C_0\exp(-c_0 NT^{2k}/\sigma^2)\}$. Against the fixed matching competitor, each conditional Gaussian divergence is at most $C_1T^{2k}/\sigma^2$ uniformly over query times in $(0,T]$. The chain rule gives this bound multiplied by $N$ for the full transcript of any adaptive randomized policy. If both errors are at most $r<1/2$, binary relative entropy requires divergence at least $(1-2r)\log((1-r)/r)$. Thus the same physical target has sharp information scales $NT^{12}/\sigma^2$ and $NT^{10}/\sigma^2$ respectively. Consistency for $N\ge d$ is equivalent to divergence of the corresponding scale, and vanishing scale rules out nonvanishing discrimination advantage.

A single random horizon $t=aT$, with $a$ uniform on $[1/2,1]$, also suffices for consistency at $\delta=o(T^k)$ over the unrestricted class. The alternative may depend on $T$ but is fixed before the draw, and the bounded noise may depend on the realized horizon. Accept when the observed matrix is within $\delta$ of the target at that horizon. Type I error is zero. For any positive spacing $\eta$, the separation proof is uniform on the compact family of $d$-tuples in $[1/2,1]$ with consecutive gaps at least $\eta$. If the nodes varied along a contradiction sequence, their limiting Vandermonde determinants, interpolation remainder constants and positive Loewner floor would still be nondegenerate, and the rational determinant in §14.3 is independent of the nodes. If the sets where $\|W_S(aT)-W_*(aT)\|\le2\delta$ had lengths bounded below by $\varepsilon>0$, one could select $d$ points from each set separated by $\varepsilon/8$, by successively removing intervals of radius $\varepsilon/8$. This contradicts uniform separation. Acceptance requires membership in these sets, so the worst-case type II error tends to zero as $T\downarrow0$ and $\delta/T^k\to0$. The same spacing argument permits a sufficiently small positive constant times $T^k$ for any prescribed positive error tolerance. At zero noise, for every $T>0$ each fixed alternative has a nonzero analytic entry of the Gramian difference by the exact heat obstruction and §2, so the test has zero error. The midpoint pair applies to random horizons at the larger constant noise level. Sections 13.3–13.4 retain the quantitative type II bound $\min\{1,C(\delta/T^k+T)^{1/(k-3)}\}$ in the capped class and the same expression with a uniform $o(1)$ replacing $T$ under the stated visible-tail condition.

The unrestricted separation and statistical conclusions, including the fixed-mass three-horizon argument, have independent ordinary mathematical review. The rational determinant has been verified by exact arithmetic. Research priority remains unverified.

## 追加锚（本行以下为增补区）

## 15. Confluent two-port separation and optimal one-horizon random design

### 15.1 Uniform separation at coalescing horizons

**Theorem 15.1.** Keep the rational six-vertex target of §13.1, its mass $M=92879135005/30751504002$ and the physical alternatives of Theorem 14.1, with at most five vertices, two labeled unit-mass ports, arbitrary positive hidden masses and nonnegative conductances, including disconnected networks. Use the actual full zero-net-current Gramian of §2. Put $m=3$ for free total mass and $m=2$ when the total mass equals $M$. For $a\in I=[1/2,1]$ and $T>0$ define

$$
Q_S(a)=\frac{W_S(aT)}{a^3T^3},\qquad R(a)=Q_S(a)-Q_*(a).
$$

There exist $c,T_0>0$ such that simultaneously for every alternative, every $0<T<T_0$ and every ordered multiset $a_0\le\cdots\le a_m$ in $I$,

$$
\max_{0\le j\le m}\|R[a_0,\ldots,a_j]\|_{\rm op}\ge cT^m.
$$

The brackets denote divided differences, extended continuously to repeated nodes by Hermite interpolation. In particular, for distinct nodes of minimum consecutive spacing $d>0$,

$$
\max_{0\le i\le m}\|W_S(a_iT)-W_*(a_iT)\|_{\rm op}
\ge c' T^{m+3}d^m .
$$

Both estimates are uniform over the unrestricted physical class, with the competitor allowed to depend on $T$ and the node multiset.

### 15.2 Uniform extraction of the slow moments

Suppose the first estimate fails along a sequence $T\downarrow0$, with every prefix divided difference of $R$ equal to $o(T^m)$. Use the notation of §14.2, with the spectral rates $\lambda_j\ge0$, port weights $A_j=v_jv_j^\top$ summing to $I_2$, and $G(a)=W_S(aT)/T^3$. Then

$$
\begin{aligned}
H(a)&=\sum_j\lambda_j A_j\int_0^1 u e^{-aT\lambda_j u}\,du,\\
G'(a)&=a^2H(a)^2,\qquad Q_S(a)=\int_0^1 u^2 H(au)^2\,du .
\end{aligned}
$$

The divided-difference product rule applied to $G-G_*=Ra^3$ gives

$$
(G-G_*)[a_0,\ldots,a_j]
=\sum_{i=0}^j R[a_0,\ldots,a_i]\,[a_i,\ldots,a_j]a^3.
$$

The polynomial differences are uniformly bounded, so every prefix difference of $G-G_*$ is $o(T^m)$, including at repeated nodes. Thus $G(a_0)$ is bounded and the first difference of $G$ has a uniformly positive definite lower bound, since the target derivative converges uniformly on $I$ to $a^2U_{1,*}^2/4$.

For $s\in I$ one has $H(1)\preceq H(s)\preceq s^{-2}H(1)$. By monotonicity on $(0,1]$ and positivity of the trace of products of positive semidefinite matrices,

$$
\operatorname{tr}G(a_0)\ge \frac{a_0^3}{3}\operatorname{tr}H(1)^2.
$$

This bounds $H(1)$ above. It then gives $H(s)^2\preceq\|H(s)\|_{\rm op}H(s)\preceq C_0 H(1)$ on $I$. Taking the average of $G'$ between $a_0,a_1$, or evaluating the derivative at a repeated node, yields a uniform lower bound on $H(1)$ as well. In particular $\kappa I_2\preceq H(1)\preceq B I_2$ along the sequence for some $\kappa,B>0$.

Write $f=\operatorname{tr}H^2$ and $q=\operatorname{tr}Q_S$. All $(-1)^rH^{(r)}$ are positive semidefinite. Every term of $(-1)^rf^{(r)}$ in the trace product rule is nonnegative, and $q$ is completely monotone by its integral expression. The highest scalar Hermite difference of $q$ differs from the corresponding target difference by $o(T^m)$. The scalar Hermite mean-value theorem and the fixed target expansion give $(-1)^m q^{(m)}(\xi)=O(T^m)$ for some $\xi\in I$. The two endpoint terms of the trace product rule imply

$$
\begin{aligned}
(-1)^m q^{(m)}(\xi)
&=\int_0^1 u^{m+2}(-1)^m f^{(m)}(\xi u)\,du\\
&\ge \frac{2\kappa}{m+3}\operatorname{tr}\big((-1)^m H^{(m)}(1)\big).
\end{aligned}
$$

Here $H(\xi u)\succeq H(1)$ and $(-1)^m H^{(m)}(\xi u)\succeq(-1)^m H^{(m)}(1)$ by the spectral formula.

Split the spectral sum at $x=T\lambda=1$, with slow rates satisfying $x\le1$. The multiplier of $A$ for a single mode in $(-1)^rH^{(r)}(a)$ is

$$
\lambda x^r\int_0^1 u^{r+1}e^{-axu}\,du .
$$

At $a=1,r=m$ this is at least $e^{-1}T^m\lambda^{m+1}/(m+2)$ on slow rates and at least $e^{-1}\lambda/((m+2)x^2)$ on fast rates, the latter by restriction to $u\le1/x$. For $x>1$ and $a\in I$ the multiplier for any fixed $r$ is at most $(r+1)!a^{-r-2}\lambda/x^2$. Consequently

$$
\operatorname{tr}U_{m+1}^{\rm slow}=O(1),
\qquad H_{\rm fast}=O_{C^m(I)}(T^m).
$$

All lower slow moments are bounded using $\sum_j A_j=I_2$ and $\lambda^j\le 1+\lambda^{m+1}$ for $j\le m+1$. The scalar Taylor remainder of the exponential after differentiation through order $m$ gives a bound by a constant times $T^m\operatorname{tr}U_{m+1}^{\rm slow}$. Thus

$$
H(a)=\sum_{\ell=0}^{m-1}\frac{(-aT)^\ell}{\ell!(\ell+2)}
U_{\ell+1}^{\rm slow}+O_{C^m(I)}(T^m).
$$

The ordered square truncated through degree $m-1$ in $aT$ has the same remainder bound. Integration of $G'=a^2 H^2$ from $1/2$ gives

$$
G(a)=K+\sum_{\ell=0}^{m-1} a^{\ell+3} T^\ell b_\ell
       +O_{C^m(I)}(T^m),
$$

where $K$ is an additive constant and $b_\ell$ is the coefficient obtained by squaring the slow expansion and integrating the corresponding monomial. In particular $b_0=(U_1^{\rm slow})^2/12$, and every subsequent $b_\ell$ is the sum of a nonzero multiple of $U_1^{\rm slow}U_{\ell+1}^{\rm slow}+U_{\ell+1}^{\rm slow}U_1^{\rm slow}$ and a polynomial in lower slow moments. The integration constant may include contributions from the fast initial layer.

The first through $m$-th prefix differences annihilate the constant and determine the coefficients of $a^3,\ldots,a^{m+2}$ by an invertible linear map, uniformly over the ordered node multisets in $I$. To see this, let $p$ be a linear combination of these powers in the kernel of that map. Then $p-p(a_0)$ has zeros at all the nodes counting multiplicity by Hermite interpolation. Repeated Rolle's theorem gives at least $m$ positive zeros counting multiplicity of $p'(a)=a^2r(a)$, where $\deg r\le m-1$. Hence $p'=0$ and $p=0$. The matrix of the map is continuous over the compact space of node multisets, so its inverse is uniformly bounded. At complete coalescence at $a$, its entries are $\binom{k}{j}a^{k-j}$ for $1\le j\le m$, $3\le k\le m+2$.

Applying this inverse to $G-G_*$ and the bounded Hermite differences of the remainders gives $T^\ell(b_\ell-b_{\ell,*})=O(T^m)$ for $0\le\ell<m$. Dividing by the indicated powers of $T$, recovering the leading positive semidefinite square root and then solving successive Sylvester equations at the positive definite limit $C=U_{1,*}$ gives

$$
U_j^{\rm slow}\longrightarrow U_{j,*}\qquad(1\le j\le m).
$$

These estimates require only the uniform control on the positive observation interval and hold for arbitrary coalescence.

### 15.3 Exclusion of escaping rates and bounded limits

At free mass $m=3$. The limiting shifted Hankel matrix

$$
\begin{pmatrix}U_{1,*}&U_{2,*}\\U_{2,*}&U_{3,*}\end{pmatrix}
$$

is positive definite of rank four as in §14.2. An escaping rate either gives no row in the slow Hankel factor or contributes a row of squared norm $(\lambda+\lambda^3)\|v\|^2=O(1/\lambda)$ by the fourth slow moment bound. At least one rate is zero by the physical ground equation, so the escape would leave at most three nonvanishing positive-rate rows. This contradicts the limiting rank four.

For fixed mass $m=2$, suppose some rates escape. Pass to a subsequence with fixed dimension, convergent eigenbasis and every rate either convergent and finite or tending to infinity. Write $P$ for the projector onto the limiting finite-rate modes, $L$ for their generator, $B=PE$ and $z$ for the limit of the ground vectors of squared norm $M$. The bounded third slow moment makes the first two moment contributions of slow escaping modes vanish. Thus $B^\top LB=C$ and $B^\top L^2B=U_{2,*}$. Also $Pz=z$, $Lz=0$, $B^\top z=\mathbf 1$ and $z^\top z=M$. If every escaping visible weight tends to zero, then $B^\top B=I_2$. The Gram of $[B,LB,z]$ equals the rank-five target Gram of $[E,S_*E,z_*]$, contradicting $\operatorname{rank}P\le4$.

Otherwise an escaping atom has visible weight $w=\|v\|^2$ bounded away from zero along a subsequence. It must be fast by the third slow moment bound. The contribution of this atom's self term to $(-1)^m q^{(m)}(\xi)$ is bounded below by

$$
c_m\lambda^2 w^2 x^m\int_0^{1/x}u^{m+2}\,du
=c'_m\frac{w^2}{T^3\lambda},
\qquad x=T\lambda>1 .
$$

Indeed on the integration interval the exponential factors in the self term and its derivatives have positive uniform lower bounds, and all other signed trace pair terms are nonnegative. As $m=2$, the bound $q^{(2)}(\xi)=O(T^2)$ forces $\lambda\ge c_0T^{-5}$.

Choose heat times tending to zero with their products with all escaping rates tending to infinity. The physical heat semigroups are entrywise nonnegative by the off-diagonal signs, and at these times they converge to $P$. Each nonzero support block of this symmetric nonnegative projection has rank one by Perron–Frobenius. Since $C\succ0$, the projected ports are independent and belong to distinct blocks, giving $B^\top B=\operatorname{diag}(b_1,b_2)$. The Schur complement of the lower block $\operatorname{diag}(U_{2,*},M)$ in the Gram of $[B,LB,z]$ is

$$
A=\operatorname{diag}(b_1,b_2)-CU_{2,*}^{-1}C-M^{-1}\mathbf1\mathbf1^\top .
$$

By §14.3 its off-diagonal lies strictly between $-72/10000$ and $-70/10000$. The Gram has rank at least four, so $\operatorname{rank}P=4$ in dimension five with exactly one escaping mode. Write $P=I-uu^\top$ for its limiting unit eigenvector $u$. Entrywise nonnegativity implies $u_i u_j\le0$ for $i\ne j$, hence at most two nonzero coordinates. Visible escape, $B^\top B$ diagonal and both projected ports nonzero force the support to consist of one port and one hidden coordinate. By target symmetry choose the first port. Then $b_2=1$, the Schur complement has rank one, and with

$$
h=(A_{22},-A_{12})^\top,\qquad \gamma=U_{2,*}^{-1}Ch,
$$

the Gram kernel identity gives $Bh=LB\gamma+z(\mathbf1^\top h/M)$. Applying $B^\top L^2$ gives $U_3^{\rm finite}\gamma=U_{2,*}h$ with $U_3^{\rm finite}=B^\top L^3B$.

For this unique fast mode let $A_f$ denote its port weight at each member of the sequence and $H_f$ its term in $H$. For all $a>0$, $a^2\|H_f(a)\|_{\rm op}\le \|A_f\|_{\rm op}/(T^2\lambda)=O(T^3)$. The finite-rate terms are uniformly bounded down to zero and the mixed terms integrated in $G$ are therefore $O(T^3)$, with the same bound through two derivatives on $I$ by differentiation of the bulk integrand. The integral of the fast self term over $[0,\infty)$ is

$$
K_T=\frac{A_f^2}{T^3\lambda}
\int_0^\infty b^2\left(\int_0^1 u e^{-bu}\,du\right)^2 db
=\frac{A_f^2}{2T^3\lambda}.
$$

The last integral is $1/2$ by integration by parts using $1-(1+b)e^{-b}$. The tail from $a$ to infinity is $O_{C^2(I)}(T^6)$ by the fast derivative bounds and integration of the bound $O(1/(b^2T^4\lambda^2))$ for the self integrand at normalized horizon $b\ge a$. Along a subsequence $T^{-2}K_T\to s e_1e_1^\top$ for $s\ge0$. This term contributes $K_T a^{-3}$ to $Q_S$, with the mixed terms and tail still $O_{C^2(I)}(T^3)$ in total.

For the actual bounded-rate moments at each member of the sequence, denoted $U_j^{\rm fin}$, the finite-rate contribution to $Q_S$ is

$$
\frac{(U_1^{\rm fin})^2}{12}
-aT\frac{U_1^{\rm fin}U_2^{\rm fin}+U_2^{\rm fin}U_1^{\rm fin}}{24}
+a^2T^2\left(
\frac{U_1^{\rm fin}U_3^{\rm fin}+U_3^{\rm fin}U_1^{\rm fin}}{80}
+\frac{(U_2^{\rm fin})^2}{45}\right)
+O_{C^2(I)}(T^3).
$$

Taking the second prefix difference of $R$ eliminates the constant and linear finite-rate terms. The value on $a^2$ is one and

$$
6\le [a_0,a_1,a_2]a^{-3}\le192
$$

by the scalar Hermite mean-value formula. Pass to a subsequence of node multisets and divide by $T^2$. The plateau and the $o(T^2)$ residual imply

$$
U_3^{\rm finite}=U_{3,*}-\tau\mathcal L_C^{-1}(e_1e_1^\top),
\qquad \mathcal L_C(Y)=CY+YC,\quad \tau\ge0 .
$$

Combined with the Gram kernel identity, this requires proportionality of the vectors $U_{3,*}\gamma-U_{2,*}h$ and $\mathcal L_C^{-1}(e_1e_1^\top)\gamma$. In the rescaled symmetric and antisymmetric coordinates of §14.3 these are precisely the rational vectors $v,w$ evaluated there, with $h=(r_-,r_+)^\top$ and $\gamma_i=c_i h_i/m_i$ in those coordinates. Their determinant lies strictly between $-38/100000$ and $-36/100000$. The contradiction excludes the visible fast escape, including a vanishing limiting plateau and complete coalescence.

It remains in each class to exclude bounded generators. Uniform expansion of $Q_S$ through degree $m$ in $aT$ has an $O_{C^m(I)}(T^{m+1})$ remainder. The prefix divided differences of the powers $1,a,\ldots,a^m$ form a triangular matrix with diagonal one and continuous entries on the compact multiset space. Its uniform inverse gives $T^\ell(W_{\ell+3,S}-W_{\ell+3,*})=o(T^m)+O(T^{m+1})$ for $0\le\ell\le m$. By the positive square root and Sylvester equations this forces $U_1,\ldots,U_{m+1}$ to converge to the target moments.

In the free-mass case take a convergent matrix subsequence. The limiting Hankel rank five forces dimension five and full visibility from the ports. The ground vectors of the physical candidates have both port entries one. If their norms diverged, normalization would produce a nonzero nonnegative vector in the limiting kernel with zero port coordinates. The sign-compatible kernel equation implies that its positive support has no conductance edges to its complement, contradicting full visibility. The ground vectors are thus bounded. Their limit has port coordinates one and is strictly positive by the same support argument. The limiting generator with this ground vector is physical. The fourth-moment rigidity argument of §13.2 identifies the hidden block up to $\alpha nn^\top$ perpendicular to the two coupling columns, and the ground equations force $\alpha=0$. The four nonnegative vectors $x,y,(4I-D)y,(4I-D)x$ have a Gram of ordinary rank three and completely positive rank four, with opposite entry $251252001/31250000000<1/36$. The cycle obstruction of §12 requires four hidden coordinates, which excludes the five-state limit.

In the fixed-mass case the ground vectors are already bounded by the mass. The limiting Gram of $[E,SE,z]$ has rank five, since it is fixed by $U_1,U_2,M$. If a coordinate of $z$ vanished, the sign-compatible kernel equation would make $E,SE,z$ all vanish there, contrary to rank five in dimension five. Hence the limiting ground vector is strictly positive. Matching $U_1,U_2,U_3$ and the mass identifies the rank-three hidden frame $[X,g]$ and its conserved compressed form $[X,g]^\top D[X,g]$ as in §13.2. The resulting port-preserving hidden isometry gives the excluded exact realization.

This proves the first inequality of Theorem 15.1 by contradiction. For distinct nodes the ordinary divided-difference formula bounds all prefix differences by $C_m\max_i\|W_S(a_iT)-W_*(a_iT)\|_{\rm op}/(T^3d^m)$ since $a_i\ge1/2$ and $d\le1$. The second inequality follows.

### 15.4 Sharp sublevel probabilities and physical contact

**Theorem 15.2.** Let $a$ be uniform on $I$ and define

$$
P_T(\varepsilon)=\sup_S\Pr\big(\|W_S(aT)-W_*(aT)\|_{\rm op}\le\varepsilon\big),
$$

where the alternative is fixed before the draw. For all sufficiently small $T>0$ and every $\varepsilon\ge0$, uniformly in these two regimes,

$$
P_T(\varepsilon)\asymp
\begin{cases}
\min\{1,(\varepsilon/T^6)^{1/3}\},&\text{free total mass},\\
\min\{1,(\varepsilon/T^5)^{1/2}\},&\text{total mass }M .
\end{cases}
$$

The constants depend only on the target and mass regime. Complete physical five-vertex alternatives attain the lower orders by contact of order exactly $m$ at any prescribed center $a_0\in I$.

For a sublevel set of positive Lebesgue length $l$ in $I$, choose $m+1$ points from it with minimum spacing at least $l/(4m)$. This is possible by successively removing intervals of radius $l/(4m)$, since $m$ such intervals remove at most $l/2$. Theorem 15.1 yields $\varepsilon\ge c T^{m+3}l^m$. The uniform probability equals $2l$, giving the claimed upper bound and zero probability at $\varepsilon=0$.

For the lower bound use the strictly interior five-vertex charts of §13.3. In free mass the complete matching base allows nearby $(C,X^\top X,X^\top DX)$ and therefore $(U_1,U_2,U_3)$ by the construction there with positive masses and strict signs. The inverse-form root is simple since its derivative $-2/\beta^2+2/f^2$ is negative, and the hidden ground vector has a nonzero normal component to the two coupling columns. At fixed mass the positive definite Gram of $[X,g]$ allows nearby $C,X^\top X$ at fixed $g^\top g=M-2$, giving $(U_1,U_2)$ with strictly positive conductances. In each case the triangular moment-to-coefficient map with $W_3=C^2/12$ and the invertible Sylvester maps provides smooth physical coefficient coordinates $p=(W_3,\ldots,W_{m+2})$ in a neighborhood of the target tuple $p_0$.

Let $F_p(t)=W_p(t)/t^3$ with analytic extension at zero. At $b=0$ the map

$$
p\longmapsto\left(\frac{F_p^{(j)}(b)}{j!}\right)_{j=0}^{m-1}
$$

is the identity in those coordinates. The parameterized implicit function theorem gives one smooth physical choice $p(b)$ for $b$ in a neighborhood of zero, with $p(0)=p_0$, such that these jets agree exactly with the target jets at $b$. Shrinking the parameter neighborhood gives a compact chart with a uniform bound on the $m$-th time derivative of $F_p-F_*$. Taking $b=a_0T$ and using Taylor's theorem gives, simultaneously for all $a,a_0\in I$ and sufficiently small $T$,

$$
\|W_{p(a_0T)}(aT)-W_*(aT)\|_{\rm op}
\le C T^{m+3}|a-a_0|^m.
$$

These are actual complete five-vertex networks, with the required total mass in the calibrated class. Theorem 15.1 at $a_0=\cdots=a_m$ makes the first unmatched normalized derivative of order $m$ nonzero. The Gramian difference itself has contact of exactly that order by multiplication by $a^3T^3$. Taking $a_0=3/4$ gives a sublevel interval of length bounded below by a constant times $\min\{1,(\varepsilon/T^{m+3})^{1/m}\}$, proving attainment of the lower scale even at arbitrarily small positive $\varepsilon$ for fixed sufficiently small $T$. More generally the confluent separation shows that the common zeros of the full matrix difference in $I$, counted with common multiplicity, number at most $m$.

### 15.5 Exact minimax risk for arbitrary common laws

**Theorem 15.3.** In the same one-horizon experiment let $\mu$ be any probability law on $I$, common to the two hypotheses and allowed to depend on $T$ and $\delta\ge0$. Observe both $a\sim\mu$ and the full symmetric matrix $Y=W_S(aT)+e(a)$, with measurable symmetric error $e$ satisfying $\|e(a)\|_{\rm op}\le\delta$ at every horizon. The target is the null hypothesis. Each hypothesis may use its own measurable error function, and the alternative and error functions may depend on $\mu,T,\delta$. The alternative is fixed before the draw, while its error function may respond to the realized horizon. For a possibly randomized test $\phi(a,Y)\in[0,1]$ giving the conditional probability of rejecting the target, define the sum of the two worst-case errors by

$$
\mathcal R_\mu(\phi)=
\sup_{e_*}\mathbb E_\mu\phi(a,W_*(aT)+e_*(a))
+\sup_{S,e_S}\mathbb E_\mu\big[1-\phi(a,W_S(aT)+e_S(a))\big].
$$

For each such common law and every $T>0,\delta\ge0$ the exact minimax identity is

$$
\inf_\phi\mathcal R_\mu(\phi)
=\sup_S\mu\{a\in I:\|W_S(aT)-W_*(aT)\|_{\rm op}\le2\delta\}.
$$

In particular for all sufficiently small $T>0$ and all $\delta\ge0$,

$$
\inf_\mu\inf_\phi\mathcal R_\mu(\phi)\asymp
\begin{cases}
\min\{1,(\delta/T^6)^{1/3}\},&\text{free total mass},\\
\min\{1,(\delta/T^5)^{1/2}\},&\text{total mass }M .
\end{cases}
$$

Uniform sampling with the target-feasibility threshold test attains the optimal order, with type I error zero. The same orders hold within a factor of two for risk defined as the maximum of the two worst-case errors.

To prove the identity, fix an alternative $S$ and let $D_S$ be the closed overlap set where the matrix distance is at most $2\delta$. On $D_S$ choose the midpoint of the two exact matrices as the common observation, and on its complement return the respective exact matrices. These two measurable error functions satisfy the pointwise bounds. At each common observation the conditional rejection probability under the target plus the conditional acceptance probability under the alternative is one, even when the test uses private randomization. Integration under the common law gives risk at least $\mu(D_S)$ on taking the separate worst cases. Taking the supremum over $S$ gives the lower bound, whether or not that supremum has a maximizer. Conversely accept the target exactly when $\|Y-W_*(aT)\|_{\rm op}\le\delta$. Its type I error is zero and type II error is possible only on $D_S$ by the triangle inequality. The midpoint choice attains $\mu(D_S)$ for each $S$, proving equality and giving an actual minimizing test for each law.

For any law and $\delta>0$ take the uniform physical contact bound of §15.4 and set

$$
h=\min\left\{\frac14,
 \left(\frac{2\delta}{CT^{m+3}}\right)^{1/m}\right\}.
$$

Partition $I$ into $N=\lceil 1/(4h)\rceil$ disjoint Borel intervals of length at most $2h$, assigning each boundary point once. Some interval has mass at least $1/N\ge2h$. Choose its midpoint $a_0$ and the corresponding physical contact network before drawing $a$. On the entire chosen interval its distance from the target is at most $2\delta$. The exact identity gives risk at least $2h$. This includes atomic and mixed laws and all laws depending on $T,\delta$. Theorem 15.2 at $\varepsilon=2\delta$ gives the matching upper order for the uniform law, including zero noise. For maximum risk, each test's maximum of the two worst-case errors lies between half their sum and their sum.

The confluent separation, exact physical contact, sublevel estimates and common-law minimax statements have independent ordinary mathematical review, including exact rational checks of the target's Hankel and calibrated Gram ranks and the determinant of §14.3. The merged Lean declaration `D5.S3.Combinatorics.SpectralGraph.TwoPortHeatRealization.exact_order_gap` establishes the exact order gap and obstruction to matching through $U_4$ used in the free-mass bounded limit. The fixed-mass argument above invokes the ordinary exact obstruction of §13.2. The confluent analytic and statistical results have ordinary mathematical proof status. Optimal multiplicative constants and limiting rescaled residual shapes remain open here. Research priority remains unverified. [Merged PR #33943](https://github.com/the-omega-institute/trureturing/pull/33943) · [Lean at merge cafdf6e69893f0728a0890878db457a8abe70d84](https://github.com/the-omega-institute/trureturing/blob/cafdf6e69893f0728a0890878db457a8abe70d84/D5/S3/Combinatorics/SpectralGraph/TwoPortHeatRealization.lean)

### 15.6 Sharp minimax risk with several randomized horizons

**定理 15.3（多时域随机观测的尖锐极小极大风险）。** Keep the rational six-vertex target $S_*$ of §13.1 and the actual full zero-net-current Gramian of §2. The alternative class $\mathcal S_m$ consists of the physical networks of Theorem 14.1 with at most five vertices, the same two labeled unit-mass ports, arbitrary positive hidden masses and nonnegative conductances, including disconnected networks. Set $m=3$ with free total mass and $m=2$ with total mass fixed at the target value $M=92879135005/30751504002$. The rates and conductances may be unbounded.

In an experiment with at most $n$ queries, a measurable policy $\pi$ chooses each normalized horizon $a_i\in I=[1/2,1]$ using private randomness and the past queries and readings. It observes the full symmetric matrix $Y_i=W_S(a_iT)+e_i$ at time $a_iT$. The symmetric errors are measurable, may depend on the hypothesis, current horizon and past transcript, and satisfy $\|e_i\|_{\rm op}\le\delta$ at every query. The same network is used for all queries. The alternative may depend on $T,\delta$ and the policy and test, and is chosen before the private seed is drawn. With $\phi$ a measurable, possibly randomized decision, define

$$
\mathfrak R_{n,m}(T,\delta)=\inf_{\pi,\phi}
\left(
\sup_{e_*}\Pr_{S_*,e_*}^{\pi,\phi}(\mathrm{reject})
+\sup_{S\in\mathcal S_m,e_S}\Pr_{S,e_S}^{\pi,\phi}(\mathrm{accept})
\right).
$$

For $1\le n\le m$ let

$$
E_{m,n}
=\min_{\substack{k_1,\ldots,k_n\in\mathbb Z_{\ge1}\\ \sum_j k_j=m}}
\sum_{j=1}^n \frac1{k_j}.
$$

There exist $c,C,T_0>0$, depending only on the target and mass class, such that for every $0<T<T_0$, every $\delta>0$ and $1\le n\le m$,

$$
c\,\min\{1,(\delta/T^{m+3})^{E_{m,n}}\}
\ \le\ \mathfrak R_{n,m}(T,\delta)\
\le\ C\,\min\{1,(\delta/T^{m+3})^{E_{m,n}}\}.
$$

The free-mass exponents at $n=1,2,3$ are $1/3,3/2,3$ on the scale $T^6$. The fixed-mass exponents at $n=1,2$ are $1/2,2$ on the scale $T^5$. Independent uniform draws in separated subintervals attain the upper orders with zero type I error. For $n\ge m+1$, $m+1$ fixed distinct horizons give zero risk whenever $0<T<T_0$ and $0\le\delta<c_0 T^{m+3}$ for a constant $c_0>0$.

**Stratified upper bound.** Fix $n$ closed subintervals $I_j$ of $I$ with positive lengths and fixed positive gaps, and draw $a_j$ independently and uniformly in $I_j$. Accept exactly when $\|Y_j-W_*(a_jT)\|_{\rm op}\le\delta$ for every $j$. This always accepts the target. For a fixed alternative $S$, let $E_j=\{a\in I_j:\|W_S(aT)-W_*(aT)\|_{\rm op}\le2\delta\}$ and let $L_j$ be its Lebesgue length. Acceptance implies $a_j\in E_j$ for every $j$, even for errors depending on the past. Its probability is at most $\prod_j L_j/|I_j|$, which is zero if any $L_j=0$.

Assume all $L_j>0$, put $B=m+1-n$, and set $\eta=A\delta/T^{m+3}$ for a constant $A\ge1$ to be chosen. When $\eta\ge1$ the risk bound by one gives the upper inequality upon enlarging $C$. For $0<\eta<1$, let $p_j$ be the largest integer in $[0,B]$ with $L_j^{p_j}>\eta$. If $\sum_j p_j\ge B$, choose integers $0\le t_j\le p_j$ with $\sum_j t_j=B$. Select $t_j+1$ points of $E_j$ separated by at least $L_j/(4m)$ by deleting an interval of radius $L_j/(4m)$ at each selection. At most $m$ deletions remove at most half the length of $E_j$. The sorted union has $m+1$ distinct nodes. At each such node $\|R(a)\|_{\rm op}\le16\delta/T^3$ in the notation of Theorem 15.1. In the explicit formula for any prefix divided difference, the denominator of the term for a node in $I_j$ contains at most $t_j$ factors from $I_j$. Each such factor in absolute value is at least $L_j/(4m)$. All other factors are bounded below by the fixed gaps. Since $L_j\le1$, the absolute denominator is at least $c_1L_j^{t_j}>c_1\eta$ with a uniform $c_1>0$. Every prefix divided difference then has norm at most $C_1\delta/(T^3\eta)=(C_1/A)T^m$, contradicting Theorem 15.1 for sufficiently large $A$.

It follows that $\sum_j p_j<B$, so every $p_j<B$ and $L_j^{p_j+1}\le\eta$. With $k_j=p_j+1$ we have $\sum_j k_j\le m$. Increasing some multiplicities to reach a sum of $m$ can only decrease the sum of reciprocals, hence $\sum_j1/k_j\ge E_{m,n}$. Thus $\prod_j L_j\le\eta^{E_{m,n}}$, proving the upper bound. The minimizing multiplicities differ by at most one. If $v\ge u+2$, replacing $u,v$ by $u+1,v-1$ strictly lowers the reciprocal sum, since $1/(v(v-1))<1/(u(u+1))$. For $m=3$ this gives $(3),(2,1),(1,1,1)$ up to permutation, and for $m=2$ it gives $(2),(1,1)$. At zero noise each fixed competitor's sublevel sets have length zero by §15.4. With $m+1$ fixed distinct nodes, the second inequality of Theorem 15.1 guarantees a gap greater than $2\delta$ at some node for every alternative when $\delta<c_0T^{m+3}$. The same acceptance test then has zero error.

**Uniform physical Hermite interpolation.** Fix $b_1,\ldots,b_n\in I$ and positive integers $k_j$ summing to $m$. Use the smooth physical coefficient charts of §15.4, with $p=(W_3,\ldots,W_{m+2})$ in a closed ball about the target coefficient tuple $p_0$ contained in the chart. They give complete five-vertex networks with positive hidden masses and conductances. The fixed-mass chart keeps the hidden squared ground-vector norm at $M-2$. Put $F_p(t)=W_p(t)/t^3$ with its analytic extension at zero, and use $F_*$ for the target. Sort the multiset of physical nodes $Tb_j$ with multiplicities $k_j$ as $s_1,\ldots,s_m$, adding multiplicities when centers coincide. The Newton data of a matrix function $F$ are

$$
\mathcal N(F)=(F[s_1],F[s_1,s_2],\ldots,F[s_1,\ldots,s_m]).
$$

For $0\le r<m$, the order-$r$ divided difference differs from $F_p^{(r)}(0)/r!$ by $O(T)$ uniformly on the ball. This follows entrywise from the Hermite mean-value formula and the uniform bounds for time derivatives on the compact chart. Applying the same estimate to the first parameter derivatives gives the $C^1$ bound $\mathcal N(F_p)=p+O_{C^1}(T)$. Likewise $\mathcal N(F_*)=p_0+O(T)$. For small $T$ the map $p\mapsto\mathcal N(F_*)-(\mathcal N(F_p)-p)$ maps the ball into itself and has Lipschitz constant at most $1/2$, uniformly over the node multiset. Its fixed point gives a physical $S$ with exactly matching Hermite jets at all the centers.

For this interpolant there are uniform constants $c_2,C_2>0$ such that at every $a\in I$,

$$
c_2 T^{m+3}\prod_{j=1}^n|a-b_j|^{k_j}
\ \le\ \|W_S(aT)-W_*(aT)\|_{\rm op}\
\le\ C_2 T^{m+3}\prod_{j=1}^n|a-b_j|^{k_j}.
$$

For the upper estimate, take a unit vector $u$, put $g(s)=u^\top(F_p-F_*)(s)u$ and let $\omega(s)=\prod_j(s-Tb_j)^{k_j}$. At $t=aT$ off the centers, $g(s)-g(t)\omega(s)/\omega(t)$ has $m+1$ zeros counting multiplicity. Repeated Rolle gives $|g(t)|\le\sup_{[0,T]}|g^{(m)}|\,|\omega(t)|/m!$. The derivative bound is uniform over the ball and the unit vectors. Take the supremum of $|g(t)|$ over $u$ and multiply by $t^3$. At a center both sides vanish.

For the reverse estimate at $a$ off the centers, append $a$ to the normalized center multiset and sort the $m+1$ nodes. The degree-at-most-$m$ Hermite interpolating polynomial of the matrix residual $R$ on these nodes has the form $D\prod_j(s-b_j)^{k_j}$ for a constant symmetric matrix $D$, because the center jets vanish. Its prefix divided differences coincide with those of $R$. The monic scalar product has uniformly bounded divided differences of orders $0,\ldots,m$ on $I$ by the bounds on its derivatives and the Hermite mean-value formula. Thus Theorem 15.1 implies $\|D\|_{\rm op}\ge c_3T^m$. Evaluating at $a$ and multiplying by $a^3T^3$, with $a^3\ge1/8$, proves the reverse estimate. Both constants are uniform through coalescence.

**Adaptive lower bound.** Fix any policy and decision, padding early stopping with ignored queries to reach $n$. Write $\mu$ for the law of $(a_1,\ldots,a_n)$ on the exact target transcript, using the policy's private seed. Take a minimizing tuple $(k_1,\ldots,k_n)$ and set

$$
h_j=\min\left\{\frac14,\left(\frac{\delta}{C_2 T^{m+3}}\right)^{1/k_j}\right\}.
$$

Partition coordinate $j$ into $N_j=\lceil 1/(4h_j)\rceil$ Borel intervals of length at most $2h_j$, assigning each boundary point once. The product partition has at most $\prod_j (2h_j)^{-1}$ cells since $h_j\le1/4$. One cell has $\mu$-mass at least $\prod_j 2h_j$, with no restriction on atoms or dependence. Choose its coordinate midpoints as the centers $b_j$ and use the interpolating network just constructed. For every $a$ in coordinate interval $j$, the product estimate gives a gap at most $C_2 T^{m+3}h_j^{k_j}\le\delta$, since all other center distances are at most one.

Under the target return exact readings. Under the chosen alternative return $W_*(aT)$ on the closed set where the gap is at most $\delta$, and return $W_S(aT)$ elsewhere. This Borel error rule uses only the current horizon and satisfies the pointwise budget. Couple all query and decision randomness across the experiments by using the same seed. For every seed whose exact-target tuple belongs to the cell, the first query receives the same answer under both hypotheses. Inductively identical histories force the same next query and that query also lies in its cell interval, so the entire transcript and decision agree. On this event the two error indicators sum to one. Taking the two separate worst cases gives risk at least $\mu(\mathrm{cell})$. The single interpolant was fixed using $\mu,T,\delta$ before the seed was drawn. The bound survives the infimum over policies because $\prod_j h_j$ is bounded below by a constant times $\min\{1,(\delta/T^{m+3})^{E_{m,n}}\}$. In fact for $\delta\ge C_2 T^{m+3}$ the one-center interpolant has gap at most $2\delta$ on all of $I$. Midpoint replies under both hypotheses then give identical transcripts for every seed and force sum risk at least one, which a constant decision attains.

The multihorizon risk and the two-sided Hermite estimate have independent ordinary mathematical review, including exact rational checks of the two physical chart base points. The merged Lean declaration cited in §15.5 proves the exact order gap and the free-mass obstruction to matching $U_0,\ldots,U_4$. The calibrated obstruction used in §15.3, the uniform physical confluent separation, the interpolation estimates and the minimax conclusions here have ordinary mathematical proof status.

## 追加锚（本行以下为增补区）

## 16. The sharp fixed-mass three-horizon constant

Use the six-vertex target $S_*$ of §13.1 and the full zero-net-current Gramian $W$ of §2. The alternatives $\mathcal S$ are physical networks on at most five vertices with the same two labeled unit-mass ports, arbitrary positive hidden masses subject to total mass $M=92879135005/30751504002$, and nonnegative conductances. This includes disconnected networks and allows unknown normalized generators with no common bound on their rates. Write $z$ for the vector of positive square roots of the masses, $E$ for the port insertion, and $U_j=E^\top S^j E$. Put $(C,V,U_*)=(U_{1,*},U_{2,*},U_{3,*})$, $\mathcal L_C(Y)=CY+YC$, and $\Phi(U)=\mathcal L_C(U-U_*)/80$. All matrix distances use the operator norm.

The merged fixed-mass theorem proves that any physical realization of this target's total mass and calibrated moments $U_1=C$, $U_2=V$, $U_3=U_*$ has at least six vertices. Thus the five-vertex moment fiber through $U_2$ excludes $U_*$ as a third moment. Independently, the merged polynomial theorem gives uniform coefficient recovery from the nonconstant Newton coefficients of $a^r\sum_{j=0}^{m-1}v_j a^j$ on a compact positive node interval, including repeated nodes. Its case $r=3$, $m=2$ controls the $a^3,a^4$ coefficients after the analytic extraction of the slow part. [Fixed-mass PR #33969](https://github.com/the-omega-institute/trureturing/pull/33969) · [Pinned moment obstruction](https://github.com/the-omega-institute/trureturing/blob/ec54f23d4a0af403b5df15cf2afa8fd0dbf50d1b/D5/S3/Combinatorics/SpectralGraph/TwoPortHeatRealization.lean#L752) · [Polynomial recovery PR #33992](https://github.com/the-omega-institute/trureturing/pull/33992) · [Pinned polynomial recovery](https://github.com/the-omega-institute/trureturing/blob/c77c578d29c78a29f768993a501a15e1014002cf/D5/S3/Analytic/Interpolation/ConfluentPositiveSampling.lean#L388)

**定理 16.1（Sharp fixed-mass leading constant）。** The minimum

$$
\mu=\min_{\substack{S\in\mathcal S\\ U_1=C,\ U_2=V}}\|\Phi(U_3)\|_{\rm op}
$$

is attained and satisfies $1/1562500<\mu<0.030574$. For every fixed triple of distinct points $a_1,a_2,a_3\in I=[1/2,1]$, put $\ell_i=1/(a_i^3\prod_{j\ne i}(a_i-a_j))$. Then

$$
\lim_{T\downarrow0} T^{-5}\inf_{S\in\mathcal S}\max_{1\le i\le3}
  \|W_S(a_iT)-W_*(a_iT)\|_{\rm op}
=\frac{\mu}{\sum_i|\ell_i|}.
$$

Every sequence with $T\downarrow0$ and bounded $T^{-5}$ residuals at the triple has a subsequence of scaled residual functions converging uniformly on $I$. The possible profiles are exactly

$$
a^3A+a^4D+a^5\Phi(U)+s e_i e_i^\top,\qquad A,D\in\operatorname{Sym}_2.
$$

The bounded-rate profiles have $s=0$ and $U=U_3$ from the moment fiber defining $\mu$. The single-fast-rate profiles have $s\ge0$ and $U$ equal to the third effective moment of a physical four-vertex generator of total mass $M$. Its port masses are $1/b$ at port $i$ and $1$ at the other port. The effective insertion is $\sqrt b\,e_i$ at the mass-$1/b$ port and the standard coordinate vector at the other port. The first and second effective moments are $C,V$, and

$$
I_2-CV^{-1}C-M^{-1}\mathbf 1\mathbf 1^\top
=\begin{pmatrix}d&o\\o&d\end{pmatrix},\qquad b=1-d+o^2/d.
$$

Each profile, including those at zero conductances and at $s=0$ in the fast branch, is recovered uniformly by a physical family defined for all sufficiently small $T>0$.

Let

$$
k=\max_{a\in I}\frac{a^3(a-1/2)(1-a)}{1+a^3(15-14a)}.
$$

The unique optimal ordered triple is $(1/2,a_{\rm mid},1)$, where $a_{\rm mid}$ is the unique maximizer in this formula. In the adaptive experiment of §15.6 let $R_n^{\rm sum}$ and $R_n^{\rm max}$ be the infima over policies and tests of the sum and maximum of the two separate worst-case errors, respectively. For each $0<\varepsilon<k\mu/2$ there is $T_0>0$ such that for all $0<T<T_0$ and all $n\ge3$,

$$
\begin{aligned}
0\le\delta\le(k\mu/2-\varepsilon)T^5
   &\ \Longrightarrow\ (R_n^{\rm sum},R_n^{\rm max})=(0,0),\\
\delta\ge(k\mu/2+\varepsilon)T^5
   &\ \Longrightarrow\ (R_n^{\rm sum},R_n^{\rm max})=(1,1/2).
\end{aligned}
$$

The alternative in the second implication can be fixed before the private seed and works for every query path in $I$, including adaptive stopping.

**Proof.** Order the three nodes and suppose the scaled residuals are bounded there. For a mode of rate $\lambda$ put $x=T\lambda$, $A_\lambda=vv^\top$ with $v$ its port projection, and $w_\lambda=\operatorname{tr}A_\lambda$. Use an orthonormal eigenbasis, counting modes with multiplicity. With $G(a)=W_S(aT)/T^3$ and $Q(a)=G(a)/a^3$, §15.2 gives

$$
H(a)=\sum_\lambda\lambda A_\lambda\int_0^1 u e^{-axu}\,du,\qquad
G'(a)=a^2H(a)^2,\qquad Q(a)=\int_0^1 u^2 H(au)^2\,du .
$$

The observations give $(\operatorname{tr} Q)[a_1,a_2,a_3]=O(T^2)$ by the target expansion. Bounded $G(a_1)$ and the uniformly positive definite first increment $G[a_1,a_2]$ give $\kappa I_2\preceq H(1)\preceq B I_2$ as in §15.2. The trace of every product of two positive semidefinite matrices is nonnegative. The trace product rule and the mean-value formula for the second difference give $\operatorname{tr}H''(1)=O(T^2)$. On $x\le1$ the integral for $H''(1)$ gives $\sum_{x\le1}\lambda^3w_\lambda=O(1)$. On $x>1$, restricting its inner integration variable to $[0,1/x]$ gives $\sum_{x>1}\lambda w_\lambda/x^2=O(T^2)$. The $x>1$ part of $H$ is thus $O(T^2)$ uniformly on $I$. There is also the per-mode bound

$$
\frac{w_\lambda^2}{T^3\lambda}=O(T^2)\qquad(x>1).
$$

Indeed at the mean-value point $\xi\in I$, $(\operatorname{tr} Q)''(\xi)$ is the integral of $u^4(\operatorname{tr} H^2)''(\xi u)$. Keep the single mode's nonnegative self-product and restrict to $u\le1/x$. Differentiating the double integral over the two inner variables in $[0,1]$ bounds the second derivative of the squared scalar multiplier below by a positive constant times $\lambda^2x^2$ on this range. Integrating in $u$ gives the estimate since $\operatorname{tr}(A_\lambda^2)=w_\lambda^2$.

Write $U_j^{\rm slow}$ for the moments restricted to $T\lambda\le1$. On $I$, $H=U_1^{\rm slow}/2-aT U_2^{\rm slow}/3+O(T^2)$ by the third slow moment bound. The first two slow moments are bounded since $\sum_\lambda w_\lambda=2$. Integrating $G'$ between observation nodes gives increment data with $O(T^2)$ remainder for the $a^3$ and $a^4$ coefficients $(U_1^{\rm slow})^2/12$ and $-T\mathcal L_{U_1^{\rm slow}}(U_2^{\rm slow})/24$. A combination of $a^3,a^4$ taking the same value at three distinct positive points has two distinct positive derivative zeros, forcing both coefficients to vanish. Thus the two increments recover these coefficients up to $O(T^2)$. The positive square root and the inverse Sylvester map are locally bounded in derivative at the target since $C\succ0$. Consequently

$$
U_1^{\rm slow}=C+O(T^2),\qquad U_2^{\rm slow}=V+O(T).
$$

Pass to a subsequence of fixed vertex count with convergent eigenvectors and ground vectors, and let every rate converge or diverge to infinity. A diverging rate contributes $o(1)$ to the first two slow moments by the third-moment bound whenever it lies in the slow sum. Let $P$ be the limit projection onto finite rates, $L$ the limiting finite-rate generator extended by zero on the orthogonal complement, $B_0=PE$, and $z$ the limiting ground vector. Since positive-rate modes are orthogonal to the ground, $Pz=z$. The recovered moments give $B_0^\top LB_0=C$, $B_0^\top L^2B_0=V$, $Lz=0$, $B_0^\top z=\mathbf 1$, and $\|z\|^2=M$. The rank of the Gram of $[B_0,LB_0,z]$ is three plus the rank of

$$
B_0^\top B_0-CV^{-1}C-M^{-1}\mathbf 1\mathbf 1^\top .
$$

If all escaping modes have vanishing limiting port weight then $B_0^\top B_0=I_2$ and this Gram has rank five by $d>|o|>0$, verified below. Hence an escape must have nonzero limiting port weight. For physical generators, $e^{-tS}$ is entrywise nonnegative by shifting $-S$ by a scalar to an entrywise nonnegative matrix before exponentiating. Taking times tending to zero that suppress all divergent rates shows $P$ is entrywise nonnegative. Each nonzero support block of a symmetric nonnegative projection has rank one by Perron–Frobenius on its irreducible blocks. Since $C\succ0$, the projected ports are nonzero and in different blocks. Thus $B_0^\top B_0$ is diagonal and the Schur complement has nonzero off-diagonal $o$. Rank is at least four, so escape requires five original vertices and exactly one divergent mode.

In the escape case $P=I-uu^\top$ for a unit vector $u$. The off-diagonal signs of $P$ imply that $u$ has at most two nonzero entries, of opposite signs if there are two. Support on one port alone would give a zero projected port and support on both ports would give collinear projections. Its visible support must therefore consist of one port and one hidden vertex. Take the port order with $B_0^\top B_0=\operatorname{diag}(b,1)$. The rank-one Schur complement gives $b=1-d+o^2/d$. In the basis of nonnegative unit block vectors of $P$, the compressed finite-rate operator $\bar S$ is physical with the stated effective insertion. For its off-diagonal signs, take the limit of $e^{-tS}$ at fixed $t>0$ and compress it by those nonnegative block vectors. The resulting $e^{-t\bar S}$ is entrywise nonnegative, so differentiating at zero gives the signs. The compressed ground has port entries $1/\sqrt b,1$. A zero coordinate of the nonnegative ground would force zero couplings to all positive ground coordinates by the ground equation and the off-diagonal signs. At that coordinate the columns of $[B_0,LB_0,z]$ would all vanish, contradicting rank four. The same argument with rank five in the bounded-rate case gives a physical five-vertex limit.

The single escaping weight $A_f$ has limiting trace $1-b>0$, so $T\lambda_f>1$ eventually by the third slow moment bound. The per-mode estimate then implies $\lambda_f\gtrsim T^{-5}$. Its self-product in $G$ is $A_f^2/(2T^3\lambda_f)$ up to $O(T^6)$ uniformly on $I$. In detail, with $j(x)=1-(1+x)e^{-x}$ the contribution is $A_f^2/(T^3\lambda_f)$ times $\int_0^{aT\lambda_f}j(x)^2\,dx/x^2$. Integration by parts with $j'(x)=xe^{-x}$ gives $1/2$ for the integral to infinity. The omitted tail is bounded by $1/(aT\lambda_f)$. The integrated mixed terms in $G$ are $O(T^3)$ since $a^2\|H_f(a)\|\le w_f/(T^2\lambda_f)$ and the finite-rate part of $H$ is bounded down to zero. Thus after division by $T^2$ the fast self-product has a subsequential limit $s e_i e_i^\top$ with $s\ge0$. The finite-rate part of $G$ has coefficients of $a^3,Ta^4,T^2a^5$ given by

$$
\frac{U_1^2}{12},\qquad -\frac{\mathcal L_{U_1}(U_2)}{24},
\qquad \frac{\mathcal L_{U_1}(U_3)}{80}+\frac{U_2^2}{45},
$$

using just the finite-rate moments in this display. The remainder is $O(T^3)$ uniformly on $I$. The first two scaled coefficient differences are bounded by the slow-moment estimates, since the sole divergent rate eventually has $T\lambda_f>1$. Subsequence limits of those differences give $A,D$. The third coefficient difference tends to $\Phi(U)$.

For recovery of an arbitrary profile prescribe

$$
C_T=(C^2+12T^2 A)^{1/2},\qquad
V_T=\mathcal L_{C_T}^{-1}\big(\mathcal L_C(V)-24TD\big).
$$

They give exactly the desired first two coefficient differences. In a bounded physical realization let $X=-S_{\rm hidden,port}\ge0$ and let $g$ be the hidden ground vector. The perturbed Gram of $Z=[X,g]$ is positive definite for small $T$ and has blocks $V_T-C_T^2$, $C_T\mathbf 1$, $M-2$. Start at the base $Z$, rotate the hidden rows, and multiply on the right by the old Gram inverse square root times the new Gram square root. For the rotation choose a row $r$ with both entries of $X$ positive, which exists since the two columns have positive inner product. Use $\exp(\sqrt T K)$ where $K_{jr}=1$, $K_{rj}=-1$ for $j\ne r$ and all other entries vanish. Each zero in $X$ gains a positive term of order $\sqrt T$, which survives the $O(T)$ Gram perturbation. The ground stays positive. Use port conductance $-(C_T)_{12}>0$, keep the hidden edge conductances including zeros, and set the hidden diagonal by $D_{\rm hid}g=X\mathbf1$. This gives a physical generator tending to the base.

At an effective fast realization, with port one merged, choose $b_T$ by the same rank-one Schur complement. For $K_T^0=I_2-C_T V_T^{-1}C_T-M^{-1}\mathbf1\mathbf1^\top$ take $b_T=1-(K_T^0)_{11}+(K_T^0)_{12}^2/(K_T^0)_{22}$ and set $G_T^0=\operatorname{diag}(b_T,1)$. The hidden coupling columns scaled by the effective insertion have Gram $F_T=V_T-C_T(G_T^0)^{-1}C_T$ and their inner products with the hidden ground are $l_T=C_T(G_T^0)^{-1}\mathbf 1$. Eliminating the port block $G_T^0$ in the rank-four Gram of the effective frame gives

$$
M-\mathbf1^\top(G_T^0)^{-1}\mathbf1=l_T^\top F_T^{-1}l_T.
$$

Indeed the remaining Gram after eliminating $G_T^0$ has rank two and upper-left block $F_T$ of rank two. At the base, $F_{11}\in(1.59,1.60)$, $F_{22}\in(1.90,1.91)$, $F_{12}\in(1.20,1.21)$ and $\det F\in(1.58,1.59)$ by the rational data below. Use the same rotation and Gram perturbation on the two hidden coupling columns to obtain an invertible positive factor $X_T$ of $F_T$. Then $g_T=X_TF_T^{-1}l_T$ approaches the positive base ground. The effective port block is $(G_T^0)^{-1/2}C_T(G_T^0)^{-1/2}$ and the unscaled couplings are $X_T(G_T^0)^{-1/2}$. Keep the hidden conductances and set the hidden diagonal by $D_{\rm hid}g_T=X_T(G_T^0)^{-1}\mathbf1$.

An effective base for this construction exists. Write $l=(l_1,l_2)^\top$ at $T=0$. Take the rows of $X$ to be $(\sqrt{F_{11}-F_{12}^2/F_{22}},0)$ and $(F_{12}/\sqrt{F_{22}},\sqrt{F_{22}})$. The solution of $X^\top g=l$ has positive second coordinate because $l_2>0$, and positive first coordinate since $l_1-F_{12}l_2/F_{22}>0$ by $1.21<l_1<1.22$ and $0.90<l_2<0.91$. The rank identity gives the required mass, and the hidden conductance can be zero.

Split the mass-$1/b_T$ port into a unit port and a hidden vertex of mass $1/b_T-1$. The isometric insertion $J$ of the effective coordinates has column $(\sqrt{b_T},\sqrt{1-b_T})^\top$ on that pair. Let $u=(\sqrt{1-b_T},-\sqrt{b_T})^\top$ on the pair, zero elsewhere. If $\bar S_T$ is the effective generator just constructed, take

$$
S_T=J\bar S_TJ^\top+\lambda_f uu^\top,\qquad
\lambda_f=\frac{(1-b_T)^2}{2(s+T)T^5}.
$$

The inter-block signs follow from $\bar S_T$ and the intra-pair sign from the large positive rate. The ground is $J\bar z_T$ with the same total mass and unit original ports. The fast mode has port weight $(1-b_T)e_i e_i^\top$ and produces the scaled plateau $(s+T)e_i e_i^\top$. The finite-rate expansion and the fast estimates give recovery on all of $I$ for every sufficiently small $T$ depending on the profile. Taking $s>0$ at the explicit base exhibits a genuine fast contribution of order $T^5$.

For evaluation at the triple, $\ell(Y)=\sum_i\ell_iY_i$ annihilates the $a^3,a^4$ terms and takes value one on $a^5$. Given $\ell(Y)=Y_0$, the least maximum of the three operator norms is $\|Y_0\|_{\rm op}/\sum_i|\ell_i|$. The triangle inequality gives the lower bound and $Y_i=\operatorname{sgn}(\ell_i)Y_0/\sum_j|\ell_j|$ attains it. The kernel of $\ell$ consists exactly of the available $a^3,a^4$ data. Thus the two branches reduce to minimizing $\|\Phi(U)\|_{\rm op}$ and $\|\Phi(U)+\rho e_i e_i^\top\|_{\rm op}$, respectively, with $\rho=s[a_1,a_2,a_3](a^{-3})\ge0$ by convexity.

For the fast comparison at port one, put $h=(d,-o)^\top$, $\gamma=V^{-1}Ch$, and $v=U_*\gamma-Vh$. The Schur complement kills $h$, so $B_0h-LB_0\gamma-z(\mathbf1^\top h/M)=0$. Applying $B_0^\top L^2$ gives $U\gamma=Vh$. With $w=\mathcal L_C^{-1}(e_1e_1^\top)\gamma$, $n=(-w_2,w_1)^\top$, and $N=\mathcal L_C^{-1}((n\gamma^\top+\gamma n^\top)/2)$, self-adjointness under the trace inner product gives

$$
\langle N,\Phi(U)+\rho e_1e_1^\top\rangle=-n^\top v/80.
$$

Here $N_{11}=n^\top w=0$. For exact rational verification put $q=1001/250000$, $p=125000/123999$, and $\mathcal P(\alpha,\beta)=\frac12\begin{pmatrix}\alpha+\beta&\alpha-\beta\\ \alpha-\beta&\alpha+\beta\end{pmatrix}$. Set $c=(p,p+2)$, $f=(3+2q,1)$ and $j=(4(3+2q)-(1+2q)^2,3)$. Block multiplication from §13.1 gives $C,V,U_*$ by applying $\mathcal P$ to the componentwise pairs $c$, $c^2+f$, $c^3+2cf+j$, respectively. To compute $\mathcal L_C^{-1}(Y)$ divide the entries in the orthonormal sum and difference basis by $c_i+c_j$ and transform back. Substitution gives $0.0924<d<0.0925$, $-0.0072<o<-0.0071$, $0.908<b<0.909$, the stated bounds on $F=V-C\operatorname{diag}(1/b,1)C$, and

$$
26<10^6N_{12}<27,\qquad 12<10^6N_{22}<13,\qquad
185<10^6|n^\top v|<187 .
$$

Since $N_{11}=0$, its trace norm satisfies $10^6\|N\|_*<\sqrt{4(27)^2+13^2}<56$. Operator-norm duality gives a fast lower bound $185/(80\cdot56)>0.04$, valid even for real $\rho$. Port exchange preserves the target moments and gives the same bound for port two.

For the bounded witness take $t=1/8$, $x=\sqrt{2+q-t^2}$, $y=(1+q)/x$, $w_0=\sqrt{2+q-y^2}$ and

$$
X=\begin{pmatrix}x&y\\0&w_0\\t&0\end{pmatrix},
\qquad g(r)=\big(r,(p-yr)/w_0,(p-xr)/t\big)^\top .
$$

Choose $r$ with $\|g(r)\|^2=M-2$ in $(0.6594121,0.6594123)$. Throughout the bracket $g(r)>0$, and the endpoint mass residuals lie in $(1.24624222,1.24624224)10^{-6}$ and $(-1.41666380,-1.41666377)10^{-6}$. Then $X^\top X=V-C^2$ and $X^\top g=C\mathbf1$. Use port edge one and hidden conductances $k_{13}=1/6$, $k_{23}=7/100$, $k_{12}=0$. With hidden coordinate vectors $e_j$ the hidden block is

$$
D_{\rm hid}=\operatorname{diag}\big((X\mathbf1)_j/g_j\big)
 +\sum_{i<j}k_{ij}(e_i/g_i-e_j/g_j)(e_i/g_i-e_j/g_j)^\top.
$$

For interval verification compute $\Phi$ by applying $\mathcal L_C/80$ to $X^\top D_{\rm hid}X-\mathcal P(j_1,j_2)$. Evaluate $X^\top D_{\rm hid}X$ as the sum of each row outer product weighted by its row sum divided by its ground entry, plus the conductance-weighted outer products of the differences of ground-scaled rows. Use rational endpoints for $r$ and interval sums, products and quotients, with square roots enclosed on the $10^{-20}$ grid. For a nonnegative rational endpoint $m/n$ use $\lfloor\sqrt{\lfloor10^{40}m/n\rfloor}\rfloor/10^{20}$ as the lower bound and add $10^{-20}$ for the upper bound. This gives enclosures $(0.0128430883,0.0128432689)$, $(-0.0124237707,-0.0124236332)$ and $(-0.0177301420,-0.0177300068)$ for $\Phi_{11},\Phi_{22},\Phi_{12}$, respectively. The maximum absolute row sum is less than $0.030574$.

For the quantitative lower certificate let $Z=[X,g]$ for any realization in the bounded moment fiber. Its Gram $G_h=Z^\top Z=Z_*^\top Z_*$ is fixed by the first two moments, mass and conservation. It is positive definite, so the hidden dimension is exactly three. The isometry $J_h=Z_*Z^{-1}$ maps into the target hidden space. With $D_0=J_h^\top D_*J_h$, block multiplication and the ground equation give

$$
Z^\top(D_{\rm hid}-D_0)Z=\begin{pmatrix}U_3-U_*&0\\0&0\end{pmatrix}.
$$

Use $\lambda_{\min}(G_h)\ge4\det G_h/(\operatorname{tr}G_h)^2>4/25$ and $C\succeq I_2$ in the inverse formula $\mathcal L_C^{-1}(Y)=\int_0^\infty e^{-tC}Y e^{-tC}\,dt$. These give $\|D_{\rm hid}-D_0\|_{\rm op}\le250\|\Phi(U_3)\|_{\rm op}$. If $\|\Phi(U_3)\|_{\rm op}\le1/1562500$, the difference is at most $\eta=1/6250$. Since $D_*\preceq4I$, $(4+\eta)I-D_{\rm hid}$ is positive semidefinite and entrywise nonnegative by the physical signs. Let $F$ have columns $X$ and $((4+\eta)I-D_{\rm hid})X$, ordered by the first and second columns of $X$, then the second and first columns of the product. Define $F_0$ using $(4I-D_0)X$ in the same order. The target hidden action sends the columns of $X_*$ into the span of $Z_*$, so $F_0^\top F_0=Q_*$, the Gram of the same ordered columns computed with $X_*$ and $(4I-D_*)X_*$. The bounds $\|X\|_{\rm op}<2$, $\|F_0\|_{\rm op}<3$ give $\|F-F_0\|_{\rm op}\le4\eta$ and $\|F^\top F-Q_*\|_{\rm op}\le24\eta+16\eta^2<1/250$. [Pinned target hidden action](https://github.com/the-omega-institute/trureturing/blob/ec54f23d4a0af403b5df15cf2afa8fd0dbf50d1b/D5/S3/Combinatorics/SpectralGraph/TwoPortHeatRealization.lean#L735)

The rational data for this lower certificate are

$$
X_*=\frac1{1000}\begin{pmatrix}1001&1\\1001&1001\\1&1001\\1&1\end{pmatrix},
\quad Y_*=\frac1{1000}\begin{pmatrix}1&1001\\1&1\\1001&1\\1001&1001\end{pmatrix},
\quad g_*=\begin{pmatrix}20875/41333\\124249/247998\\20875/41333\\126251/247998\end{pmatrix}.
$$

Compute $G_h=[X_*,g_*]^\top[X_*,g_*]$ and $Q_*$ using $Y_*Y_*^\top X_*$ for the product columns. Direct rational multiplication gives $25\det G_h>(\operatorname{tr}G_h)^2$, maximum absolute row sum of $X_*^\top X_*$ less than $4$, and $\operatorname{tr} Q_*<9$. With indices modulo four it gives $4-Q_{*,ii}>1/250$, $Q_{*,i,i+1}-1>1/250$, and $1/36-Q_{*,i,i+2}>1/250$. Hence the perturbed Gram has diagonals at most $4$, cycle entries at least $1$ and opposite entries less than $1/36$. A nonnegative factor on three rows violates the four-cycle width inequality. Every cycle edge has a row where its adjacent entries have product at least $1/3$, hence both entries are at least $1/6$ by the diagonal bound. Among four edges two must use the same row, producing an opposite pair of product at least $1/36$, a contradiction. [Pinned rational target](https://github.com/the-omega-institute/trureturing/blob/ec54f23d4a0af403b5df15cf2afa8fd0dbf50d1b/D5/S3/Combinatorics/SpectralGraph/TwoPortHeatRealization.lean#L42) · [Pinned four-cycle width inequality](https://github.com/the-omega-institute/trureturing/blob/ec54f23d4a0af403b5df15cf2afa8fd0dbf50d1b/D5/S3/Combinatorics/SpectralGraph/FourPortHeatRealization.lean#L46)

The bounded witness makes the fiber nonempty. Along a minimizing sequence $U_3$ is bounded by invertibility of $\mathcal L_C$. The fixed Gram bounds $Z$ and $Z^{-1}$. The upper-left block of $Z^\top D_{\rm hid}Z$ is bounded by $U_3$, and its other blocks are $X^\top X\mathbf1$, its transpose, and $\mathbf1^\top C\mathbf1$ by conservation. This bounds $D_{\rm hid}$. The rank-five ground argument gives a physical subsequential limit, so the attained minimum inherits the strict lower certificate. Recovery gives the upper limit for the triple with that minimum. Along any sequence realizing the lower limit, choose alternatives within $o(T^5)$ of the infimum. Their scaled residuals at the triple are bounded, so the outer-limit argument applies. The strict fast comparison and the least-maximum norm formula give the claimed lower limit.

For time design take

$$
P_k(a)=a^3\big((a-1/2)(a-1)+k(15-14a)\big).
$$

The maximizing formula for $k$ gives $P_k(a)\ge-k$ on $I$, and $P_k(1/2)=P_k(1)=k$. With $y=1-a$, the denominator of the ratio after canceling $a^3$ is at least $2+14y$, and $68(1/2-y)y<2+14y$ since $20y-68y^2\le25/17$. Hence $k<1/68$. Now

$$
P_k(a)-k=(a-1/2)(1-a)\big(-a^3+2k(7a^2+3a+1)\big).
$$

The bracket is strictly negative since $2(7a^2+3a+1)/a^3\le68$ on $I$. The derivative of the ratio defining $k$ has the sign of $28a^6-60a^5+31a^4-10a^2+12a-3$. At $a=(t+1/2)/(1+t)$, multiplying that polynomial by $32(1+t)^6$ gives ascending coefficients $(32,256,702,816,288,-128,-64)$. Descartes' rule and opposite endpoint signs give a unique interior maximizer, where $P_k(a_{\rm mid})=-k$. Since the coefficient of $a^5$ in $P_k$ is one, any triple satisfies $1=\ell(P_k)\le k\sum_i|\ell_i|$. Equality requires the three alternation points, and they attain it because the signs of $\ell_i$ in increasing order are $+,-,+$.

Below the threshold use the optimal triple and accept the target exactly when each reading lies in its target noise ball. The distance limit ensures every alternative has a query with distance greater than $2\delta$, giving both errors zero. Above the threshold take an attaining bounded realization for $\mu$ and recover the profile $P_k(a)\Phi(U_3)$ using the free $a^3,a^4$ coefficients. Uniform recovery gives a single physical alternative $S_T$ with distance at most $2\delta$ on all of $I$. Under either hypothesis return the common midpoint at every queried horizon. The responses satisfy the per-query bound and are measurable. Coupling the query and decision seeds gives identical histories, stopping and decisions by induction. The two errors for this pair sum to one, so the separate worst-case errors have sum at least one and maximum at least $1/2$ for every test. A constant decision attains sum one and an independent fair coin attains maximum $1/2$. The same $T_0$ works for all $n\ge3$ because the upper test uses three queries and the midpoint rule works on the entire interval.

The prefactor, physical recovery, quantitative certificates and adaptive threshold have ordinary mathematical proof status. The derivation and independent replay are recorded in the research files two-port-fixed-mass-leading-constant.txt and two-port-fixed-mass-leading-constant-audit.txt. The quantitative bounded-fiber estimate is recorded under the fixed-mass three-horizon frontier in the accompanying research ledger. The exact value of $\mu$, risk at critical equality, and the sharp constants for one or two randomized or adaptive queries remain open.

## 追加锚（本行以下为增补区）

## 17. Sharp local physical moment inversion and Hermite design

### 17.1 Local inversion and deterministic minimax recovery

**Theorem 17.1.** Use a complete five-vertex matching base of §13.3, with two labeled unit-mass ports, and the smooth physical family there described. Put $m=2$ at the fixed total mass $92879135005/30751504002$ and $m=3$ for free mass. Let $U_q=E^\top S^qE$ be the calibrated moments of the mass-normalized generator $S$, where $E$ inserts the ports. The family has open coordinates $p=(b_0,\ldots,b_{m-1})$, with $b_\ell=[t^{\ell+3}]W_p(t)$ for the actual Gramian of §2. Write $p_0$ for the base and $\kappa=\lambda_{\min}(U_1(p_0))=125000/123999$.

For any multiset $1/2\le a_0\le\cdots\le a_m\le1$ define $\mathcal H_{\mathbf a}f=([a_0,\ldots,a_j]f)_{j=1}^m$, with Hermite divided differences at repeats (a derivative of order $j$ at complete coalescence is divided by $j!$). Define the actual observations, their center and the scalar sampling matrix by

$$
Y(p)=\mathcal H_{\mathbf a}(a\mapsto T^{-3}W_p(aT)),\qquad y_0=Y(p_0),\qquad M_{j\ell}=[a_0,\ldots,a_j]a^{\ell+3}.
$$

All blocks are real symmetric $2\times2$ matrices, with Euclidean operator norm and the maximum block norm $\|\cdot\|_\infty$ on tuples. For each fixed $A>0$, all sufficiently small $T>0$ and all node multisets, there is a smooth physical inverse $p(y)$ in this family on a neighborhood of $\|y-y_0\|_\infty\le AT^m$. Set $u_k(y)=U_{k+1}(p(y))$ for $0\le k<m$. Then, with

$$
L_k(\mathbf a)=\frac{(k+3)k!(k+2)}{\kappa}\sum_{j=1}^m |(M^{-1})_{kj}|,
$$

one has $\|T^k D u_k(y_0)\|_{\infty\to\mathrm{op}}=L_k(\mathbf a)+O(T)$ and, for every $0<\varepsilon\le AT^m$,

$$
\sup_{\|y-y_0\|_\infty\le\varepsilon}T^k\|u_k(y)-u_k(y_0)\|_{\mathrm{op}}
=\varepsilon L_k(\mathbf a)+O_A(T\varepsilon).
$$

For any $r\ge\varepsilon>0$ with $r+\varepsilon\le AT^m$, the parameter set is the physical preimage of the closed observation ball of radius $r$ about $y_0$. Given one data tuple $y+\eta$ with $\|\eta\|_\infty\le\varepsilon$, the deterministic minimax risk for loss $T^k\|\widehat U-U_{k+1}\|_{\rm op}$ is $\varepsilon L_k(\mathbf a)+O_A(T\varepsilon)$. All errors are uniform through arbitrary coalescence and for arbitrarily small positive noise. At complete coalescence at $1/2$, the constants in increasing moment order are $(32,72)/\kappa$ and $(78,348,736)/\kappa$, respectively.

**Proof.** Write the physical generator and positive ground vector as

$$
S=\begin{pmatrix}C&-X^\top\\-X&D\end{pmatrix},\qquad z=(1,1,g^\top)^\top,\qquad X^\top g=C\mathbf1,\quad Dg=X\mathbf1.
$$

The masses are $z_i^2$ and the conductances are $-z_iS_{ij}z_j$ for $i\ne j$. Set $B=X^\top X$, $J=X^\top DX$. Block multiplication gives $U_1=C$, $U_2=C^2+B$ and $U_3=C^3+CB+BC+J$. In the fixed-mass construction of §13.2 the three-column Gram of $[X,g]$ is positive definite. Its Schur complement in the $B$ block equals $g^\top g-2\kappa^2/(3+2q)>0$ for the explicit target data. At the complete matching base let this Gram be $Q_0$. For nearby $C,B$ prescribe

$$
Q=\begin{pmatrix}B&C\mathbf1\\\mathbf1^\top C&g_0^\top g_0\end{pmatrix},\qquad [X,g]=[X_0,g_0]Q_0^{-1/2}Q^{1/2}.
$$

The columns remain strictly positive. Prescribe port edge $-C_{12}$, coupling conductances $g_iX_{ij}$ and the base hidden conductances. Conservation determines the diagonals and gives the requested $C,B$ at precisely the fixed mass.

At free mass choose $X=X_0B_0^{-1/2}B^{1/2}$ near the complete matching base. In the orthonormal hidden frame formed by $XB^{-1/2}$ and a smoothly chosen unit normal, write the blocks of $D$ as $V=B^{-1/2}JB^{-1/2}$, $\xi$ and last diagonal $d>0$. Put $\nu=B^{-1/2}C\mathbf1$ and $\omega=V\nu-B^{1/2}\mathbf1$. Conservation in this frame requires the ground coordinates $(\nu,-\xi^\top\nu/d)$ and $\xi\xi^\top\nu/d=\omega$. The ground's normal coordinate is nonzero at the base by §13.3, so $\nu^\top\omega=(\xi^\top\nu)^2/d>0$. Keeping $d$ fixed, choose

$$
\xi=\pm\sqrt d\,\frac{\omega}{\sqrt{\nu^\top\omega}}
$$

with the base sign. This realizes arbitrary nearby $(C,B,J)$, with the prescribed ground equations and strict physical signs by continuity. Both families are smooth, bounded on compact subcharts, and have $C_0=\kappa I+\left(\begin{smallmatrix}1&-1\\-1&1\end{smallmatrix}\right)$. The smallest-eigenvalue projection at the base is $P=\mathbf1\mathbf1^\top/2$.

The actual heat identity of §15.2, now with the full finite generator, gives

$$
T^{-3}W_p(aT)=\int_0^a s^2H_p(s,T)^2\,ds,\qquad H_p(s,T)=E^\top S\left(\int_0^1 v e^{-sTvS}\,dv\right)E.
$$

On a compact subchart every rate satisfies $T\lambda\le1$ for small $T$, so the slow moments of §15.2 coincide with all the above moments. Expanding the exponential and retaining the matrix product order gives

$$
H_p(s,T)=\sum_{i\ge0} c_i(sT)^i U_{i+1},\quad c_i=\frac{(-1)^i}{i!(i+2)},\qquad
b_\ell=\frac1{\ell+3}\sum_{i=0}^{\ell}c_ic_{\ell-i}U_{i+1}U_{\ell-i+1}.
$$

In particular, using $\{C,Z\}=CZ+ZC$,

$$
b_0=U_1^2/12,\qquad b_1=-\{U_1,U_2\}/24,\qquad b_2=\{U_1,U_3\}/80+U_2^2/45.
$$

The triangular map from moments to $b_k$ has diagonal derivative $\alpha_k\mathcal L_{U_1}$, where $\mathcal L_C Z=CZ+ZC$ and $\alpha_k=(-1)^k/(2(k+3)k!(k+2))$. The formula follows from the two endpoint terms for $k>0$ and differentiation of the square for $k=0$. For $C\succ0$ the Sylvester map has eigenbasis multipliers $\lambda_i(C)+\lambda_j(C)>0$. Its inverse norm on symmetric matrices with operator norm is exactly $1/(2\lambda_{\min}(C))$. Indeed, for $Z=\mathcal L_C X$ take a unit eigenvector $v$ of $X$ of eigenvalue with largest absolute value. Then $|v^\top Zv|=2|v^\top Xv|v^\top Cv\ge2\lambda_{\min}(C)\|X\|_{\rm op}$. Equality holds on a smallest-eigenvalue projection. Thus the moment and coefficient charts are locally smoothly equivalent. In the triangular inverse $\Psi_k(p)=U_{k+1}(p)$ only $b_0,\ldots,b_k$ occur and $D_{b_k}\Psi_k=\alpha_k^{-1}\mathcal L_{U_1(p)}^{-1}$.

Each entry of $M$ is polynomial in its prefix nodes by monic polynomial division, including at repeats. If $M\beta=0$, the polynomial $f(a)=\sum_{\ell<m}\beta_\ell a^{\ell+3}$ differs from its value at $a_0$ by a polynomial with $m+1$ roots at the nodes counting multiplicities. Rolle's theorem gives at least $m$ positive roots of $f'$. Since $f'=a^2 h(a)$ with $\deg h\le m-1$, one has $\beta=0$. Compactness yields a common finite bound $K$ on $\|M^{-1}\|_\infty$.

Take a closed convex ball of radius $\rho>0$ about $p_0$ inside the coefficient chart. The extension of $W_p(t)/t^3$ to zero is analytic in time and smooth in the physical parameters, so

$$
W_p(t)/t^3=\sum_{\ell<m}b_\ell t^\ell+t^m Q(p,t),\qquad
Y(p)=MD_Tp+T^mR(p),
$$

where $D_T=\operatorname{diag}(T^\ell)_{0\le\ell<m}$ and $R(p)=\mathcal H_{\mathbf a}(a\mapsto a^{m+3}Q(p,aT))$. The mixed derivatives $\partial_t^j D_pQ$ for $0\le j\le m$ are bounded on this ball times a fixed small time interval by the matrix exponential series and Taylor's formula. For symmetric matrix functions the Hermite mean-value bound

$$
\|[a_0,\ldots,a_j]f\|_{\rm op}\le\sup_{a\in I}\|f^{(j)}(a)\|_{\rm op}/j!,\qquad I=[1/2,1],
$$

follows by applying the scalar bound to every unit-vector quadratic form. The scalar bound uses the degree-at-most-$j$ Hermite interpolant and Rolle's theorem with multiplicities. Apply it to the parameter derivative and integrate along the segment from $p'$ to $p$. This gives $\|R(p)-R(p')\|_\infty\le L\|p-p'\|_\infty$ with $L$ uniform in $T,\mathbf a$.

Use $z'=D_T(p-p_0)$ as the scaled coefficient displacement (independent of the ground vector $z$) and $e=y-y_0$. Then $e=Mz'+N(z')$, where

$$
N(z')=T^m\big(R(p_0+D_T^{-1}z')-R(p_0)\big),\qquad\operatorname{Lip}(N)\le LT.
$$

For $KLT\le1/2$ the map $z'\mapsto M^{-1}(e-N(z'))$ is a contraction on the closed ball of radius $\rho T^{m-1}$ into itself whenever $\|e\|_\infty\le\rho T^{m-1}/(2K)$. It gives an exact physical preimage. The same Lipschitz inequality gives injectivity on the entire scaled chart ball, and the derivative is invertible there. In particular the inverse is smooth on a neighborhood of the stated observation ball for small $T$. For two such observations, writing $\Delta$ for their difference, the contraction equations give

$$
\|\Delta z'\|_\infty\le 2K\|\Delta y\|_\infty,\qquad \Delta z'=M^{-1}\Delta y+O(T\|\Delta y\|_\infty).
$$

Both reconstructions are $O_A(T)$ from $p_0$. Integrating the derivative of $\Psi_k$ on their segment, each lower coefficient $b_\ell$ with $\ell<k$ contributes $O(T^{k-\ell}\|\Delta z'\|_\infty)$ in the scaled norm and the diagonal derivative differs from its base value by $O_A(T)$. Hence

$$
T^k\Delta u_k=\alpha_k^{-1}\mathcal L_{C_0}^{-1}\left(\sum_j(M^{-1})_{kj}\Delta y_j\right)+O_A(T\|\Delta y\|_\infty).
$$

The leading linear operator has norm $L_k(\mathbf a)$. Its upper bound follows by the triangle inequality and the Sylvester norm, and equality follows for the unit tuple $(v_k)_j=\operatorname{sgn}((M^{-1})_{kj})P$, taking sign zero at zero. The inverse produces physical networks with data $y_0+\varepsilon v_k$ and $y_0$. This proves the asserted sharp modulus, and taking a difference quotient at the center proves the derivative norm estimate. Substitution of $M_{j\ell}=\binom{\ell+3}{j}(1/2)^{\ell+3-j}$ gives the coalescence examples.

For minimax recovery, invert the noisy datum and return $\Psi_k(p(y+\eta))$. The last pairwise estimate bounds its worst-case error by $\varepsilon L_k+O_A(T\varepsilon)$. Nonsymmetric additive errors, if allowed, can first be symmetrized, which is nonexpansive in operator norm. For the lower bound the two physical preimages of $y_0\pm\varepsilon v_k$ are in the parameter set and both can return $y_0$. Their scaled moment separation is $2\varepsilon L_k+O_A(T\varepsilon)$, forcing any deterministic estimator to incur at least half that separation. If $0<r<\varepsilon$ with $r+\varepsilon\le AT^m$, the same comparison using $r$ and the constant estimator at $y_0$ give risk $rL_k+O_A(Tr)$.

### 17.2 Exact highest-row design

**Theorem 17.2.** More generally let $m\ge1$ and $0<a_0\le\cdots\le a_m\le b$, with $M$ defined as in Theorem 17.1. For independently bounded positive-order Hermite coefficient errors in operator norm, the exact highest polynomial coefficient amplification is the row sum $\sum_{j=1}^m |(M^{-1})_{m-1,j}|$. It decreases strictly in each node and has its unique minimum at $a_0=\cdots=a_m=b$. At this multiset, with $n=m+1$, the individual absolute entries are

$$
|(M^{-1})_{m-1,j}|=\frac{j(n-j)}{n+1}\,b^{-(n+1-j)},\qquad 1\le j\le m.
$$

At $b=1$ the row sum is $m(m+1)/6$. In the two physical charts on $[1/2,1]$, the unique leading-order design minimizing the highest-moment scaled local modulus and minimax constant of Theorem 17.1 is therefore complete coalescence at $1$. The minimum constants for $T\Delta U_2$ at fixed mass and $T^2\Delta U_3$ at free mass are $12/\kappa$ and $80/\kappa$, respectively.

**Proof.** Put $r_i=1/a_i$. For the $j$-th inverse column partition the reciprocals into the lists $S_j=(r_0,\ldots,r_{j-1})$ and $U_j=(r_j,\ldots,r_m)$. Use $s_1=e_1(S_j)$, $u_i=e_i(U_j)$, $h_S=s_1^2-e_2(S_j)$ and $H=h_2(S_j\cup U_j)$, where $e_i$ are elementary symmetric functions and $h_2=e_1^2-e_2$, with multiplicities retained. Write $P_j(x)=\prod_{i<j}(x-a_i)$ and $N(x)=\prod_{i\le m}(x-a_i)$. The positive-order prefix Newton data of $P_j$ form the $j$-th unit vector, including repeated nodes. Every polynomial $x^3p(x)$, $\deg p<m$, with those data has the form $P_j(x)+c+N(x)(\alpha+\beta x)$ by Hermite interpolation. Cancel the coefficients of $x,x^2$ using $N_1/N_0=-(s_1+u_1)$ and $N_2/N_0=e_2(S_j\cup U_j)$. The two equations in $\alpha,\beta$ have determinant $-N_0^2H\ne0$. The constant $c$ then cancels the constant coefficient. The highest coefficient is

$$
\beta=-\frac{P_j(0)}{N(0)}\frac{u_1h_S+s_1u_2}{H},\qquad
|(M^{-1})_{m-1,j}|=\left(\prod_{r\in U_j}r\right)\frac{B}{H},\quad B=u_1h_S+s_1u_2.
$$

For a reciprocal $x\in S_j$, differentiation of $B/H$ gives numerator

$$
(u_1^2-u_2)\big(e_2(S_j)+s_1x+u_1(s_1+x)+u_2\big)>0.
$$

For a reciprocal $x\in U_j$, let $v_1,v_2$ be the first two elementary symmetric functions of the remaining entries of $U_j$. Write $H=x^2+Rx+H_0$, $B=C_1x+B_0$, where $R=s_1+v_1$, $C_1=h_S+s_1v_1$, $B_0=v_1h_S+s_1v_2$, $H_0=h_2(S_j\cup(U_j\setminus\{x\}))$ (remove one occurrence). The numerator of the derivative of $xB/H$ is

$$
(C_1R-B_0)x^2+2C_1H_0x+B_0H_0,\qquad
C_1R-B_0=s_1\big(h_S+v_1(s_1+v_1)-v_2\big)>0.
$$

Here $H_0,C_1>0$ and $B_0\ge0$, so this numerator is strictly positive. Each absolute entry increases strictly in every reciprocal. Under $r_i\ge1/b$ the unique minimum has all reciprocals $1/b$. Substitution gives the displayed entries and summing at $b=1$ gives $m(m+1)/6$. For symmetric matrix data the triangle inequality gives the exact highest coefficient bound, attained by independent sign-weighted observations along a common rank-one projection. In the physical inverse choose that projection to be $P$ from Theorem 17.1. Multiplication by $(m+2)(m-1)!(m+1)/\kappa$ gives the two sharp leading constants. The optimum here concerns the leading constants for direct Hermite noise.

### 17.3 Physical ambiguity with an additional hidden parameter

**Proposition 17.3.** In either regime of Theorem 17.1, every open physical neighborhood of the complete matching base contains, for all sufficiently small $T$ and all node multisets in $[1/2,1]$, two actual physical networks with identical positive-order Hermite data $Y$ but distinct moments $U_{k+1}$ for every $0\le k<m$. A single additional hidden parameter suffices. The generators remain bounded and the fixed-mass example retains the exact calibrated mass. For each fixed sufficiently small nonzero auxiliary change the unscaled moment separations are of order $T^{m-k}$, uniformly in the node multiset.

**Proof.** At fixed mass keep $C,X,g$ at the base and add $sww^\top$ to $D$ for $w=e_i/g_i-e_j/g_j$, changing one hidden conductance by $s$. There is a hidden pair with $X^\top w\ne0$, since otherwise both columns of $X$ are proportional to $g$, contradicting the rank-three Gram. This preserves conservation, mass and the first two moments, and changes $U_3$ by $s(X^\top w)(X^\top w)^\top$.

At free mass keep $C,X,J$ fixed and vary the last diagonal $d$ of the hidden block in the Schur construction of Theorem 17.1, choosing $\xi$ by its same smooth formula. The first three moments stay fixed. Block multiplication gives

$$
U_4=(C^2+B)^2+(XC+DX)^\top(XC+DX).
$$

Only the contribution $B^{1/2}\xi\xi^\top B^{1/2}$ to $X^\top D^2X$ varies, and $\xi\xi^\top=d\,\omega\omega^\top/(\nu^\top\omega)$ with $\omega\ne0$. Thus the next moment changes nontrivially. Small auxiliary changes in either regime retain strict physical signs and positive masses. The coefficient formula in Theorem 17.1 implies that $b_0,\ldots,b_{m-1}$ are preserved and the next coefficient changes by a nonzero matrix $\Delta b_m$.

The perturbed network's observation is $y_0+T^m w_{\mathbf a}\Delta b_m+O(T^{m+1})$ with $w_{\mathbf a}=\mathcal H_{\mathbf a}(a^{m+3})$ (the error is uniform by the Hermite mean-value bound). The original chart gives a second actual network with precisely these data. The first $m$ moments of the perturbed network equal those of the base. By the pairwise inverse estimate, the scaled difference between the matching chart moment and the perturbed network's moment is

$$
T^k\Delta U_{k+1}=T^m(M^{-1}w_{\mathbf a})_k\alpha_k^{-1}\mathcal L_{C_0}^{-1}\Delta b_m+O(T^{m+1}).
$$

Every scalar factor $(M^{-1}w_{\mathbf a})_k$ is nonzero. By Cramer's rule its numerator is the determinant of $M$ with column $k$ replaced by $w_{\mathbf a}$. The columns still sample $m$ distinct monomials of positive degree. A vanishing Newton tail would give $m+1$ positive roots counting multiplicities after subtracting a constant, hence $m$ positive roots of the derivative. A nonzero polynomial with at most $m$ nonzero monomials has at most $m-1$ positive roots counting multiplicities. To see this, divide by its smallest power of the variable, differentiate to remove the constant, and apply Rolle's theorem and induction on the number of monomials. This excludes a singular replacement matrix. Continuity and compactness give a uniform positive lower bound on the absolute scalar factors. With a fixed nonzero sufficiently small auxiliary change, all the differences displayed above are nonzero for small $T$. The chart reconstructions tend uniformly to the base, and the perturbed network can be placed in the prescribed neighborhood by choosing the auxiliary change small enough.

### 17.4 Provenance, observation metric and formal scope

This append batch was composed by Codex from the ordinary proofs and independent mathematical audit of 25 November 2026, recorded in two-port-hermite-moment-sharp-inverse-proof.txt, two-port-hermite-inversion-design-audit-result.txt and two-port-hermite-highest-moment-design.txt. The underlying physical chart and the rational target are those of §13. The center here is the actual five-vertex base, and the local modulus concerns reconstructions in its chosen chart. The physical sharp inverse, minimax theorem, general highest-row design and additional-parameter ambiguity have ordinary proof status. Research priority remains unverified.

The measurement norm is that of the $m$ positive-order Hermite coordinates of $G(a)=W(aT)/T^3$, independently bounded at the readout. Distinct raw horizon readings instead induce correlated errors by the divided-difference linear map with factor $T^{-3}$. For minimum spacing $h>0$ and raw error bound $\delta$, order $j$ has error at most $\delta T^{-3}2^j/(j!h^j)$, by the Lagrange formula and the ordered spacings. Repeated-node readout requires derivatives. Theorem 17.2 optimizes the leading direct-Hermite risk, and exact finite-$T$ nonlinear design remains open.

The merged polynomial theorem `D5.S3.Analytic.Interpolation.ConfluentPositiveSampling.weightedNewtonTail_uniform_lower` of PR #33992 proves uniform qualitative recovery of the weighted polynomial coefficients on a positive compact interval, including repeated nodes. PR #34010 supplies `hermiteTail` and `matrixHermiteTail` using actual within-interval jets and proves `hermiteTail_noisy_recovery` and `matrixHermiteTail_noisy_recovery`. For a decomposition $F=K+a^r p(a)+E(a)$ with constant $K$, $r>0$, smooth remainder and bounds on its within derivatives of orders $1,\ldots,m$, these declarations bound the coefficient norm by the tail norm plus the maximum factorial-scaled derivative bounds, with a uniform positive constant depending on the interval, $m,r$ (a two-port operator-norm version with factor two over the scalar inverse bound). These are merged qualitative supplier results. [Polynomial PR #33992](https://github.com/the-omega-institute/trureturing/pull/33992) · [Pinned polynomial theorem](https://github.com/the-omega-institute/trureturing/blob/c77c578d29c78a29f768993a501a15e1014002cf/D5/S3/Analytic/Interpolation/ConfluentPositiveSampling.lean#L388) · [Hermite PR #34010](https://github.com/the-omega-institute/trureturing/pull/34010) · [Pinned scalar observation theorem](https://github.com/the-omega-institute/trureturing/blob/f68ac7d929ef8e5bb69a7695ecdf45cf822f1128/D5/S3/Analytic/Interpolation/ConfluentHermiteObservation.lean#L598) · [Pinned matrix observation theorem](https://github.com/the-omega-institute/trureturing/blob/f68ac7d929ef8e5bb69a7695ecdf45cf822f1128/D5/S3/Analytic/Interpolation/ConfluentHermiteObservation.lean#L672)

A separate scalar $m=2$ highest-coefficient theorem for `weightedNewtonTail 3` has scoped Lean kernel evidence for the explicit inverse, unique optimal unit endpoint triple and sharp worst-case scalar noise bound. The saved `HermiteHighestCoefficient.verified.lean` has SHA-256 `b7895696a6f2e08bed99d61e43404f94fc70626e018a1d11a2b0dc6c63294a9c` and `hermite-highest-row-scoped-report.json` has SHA-256 `dfbb11c754f3e00a9fb1a187e8703d0d0069b1d8d6e5431f51d5d8fd2c87474d`, with only standard Lean axioms. Its formal merged delivery is pending. These receipts concern scalar polynomial observations. The new physical conclusions above remain outstanding for formalization.

## 追加锚（本行以下为增补区）
