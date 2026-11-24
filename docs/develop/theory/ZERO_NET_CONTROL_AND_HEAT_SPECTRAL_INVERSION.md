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
